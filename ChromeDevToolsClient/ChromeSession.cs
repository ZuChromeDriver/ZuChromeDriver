namespace Zu.ChromeDevTools
{
    using System;
    using System.Collections.Concurrent;
    using System.Net.WebSockets;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a websocket connection to a running chrome instance that can be used to send commands and recieve events.
    /// </summary>
    public partial class ChromeSession : IDisposable
    {
        private readonly string _endpointAddress;
        private readonly ILogger<ChromeSession> _logger;
        private readonly ConcurrentDictionary<string, ConcurrentBag<Action<object>>> _eventHandlers = new();
        private readonly ConcurrentDictionary<Type, string> _eventTypeMap = new();

        private ClientWebSocket _sessionSocket;
        private CancellationTokenSource _receiveLoopCancellationTokenSource;
        private Task _receiveLoopTask;
        private readonly SemaphoreSlim _connectionSemaphore = new(1, 1);
        private readonly SemaphoreSlim _sendSemaphore = new(1, 1);
        private long _currentCommandId = 0;

        public delegate void DevToolsEventHandler(object sender, string methodName, JsonNode eventData);
        public event DevToolsEventHandler DevToolsEvent;
        /// <summary>
        /// Gets or sets the number of milliseconds to wait for a command to complete. Default is 5 seconds.
        /// </summary>
        public int CommandTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the endpoint address of the session.
        /// </summary>
        public string EndpointAddress
        {
            get { return _endpointAddress; }
        }


        /// <summary>
        /// Creates a new Chrome session to the specified WS endpoint without logging.
        /// </summary>
        /// <param name="endpointAddress"></param>
        public ChromeSession(string endpointAddress)
            : this(null, endpointAddress)
        {
        }

        /// <summary>
        /// Creates a new ChromeSession to the specified WS endpoint with the specified logger implementation.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="endpointAddress"></param>
        public ChromeSession(ILogger<ChromeSession> logger, string endpointAddress)
            : this()
        {
            if (String.IsNullOrWhiteSpace(endpointAddress))
                throw new ArgumentNullException(nameof(endpointAddress));

            CommandTimeout = 5000;
            _logger = logger;
            _endpointAddress = endpointAddress;

            _sessionSocket = CreateSessionSocket();
        }

        /// <summary>
        /// Sends the specified command and returns the associated command response.
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <param name="throwExceptionIfResponseNotReceived"></param>
        /// <returns></returns>
        public async Task<ICommandResponse<TCommand>> SendCommand<TCommand>(TCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
            where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var opts = ChromeDevToolsJsonSerializerOptions.Instance;
            var paramsNode = JsonSerializer.SerializeToNode(command, command.GetType(), opts);
            var result = await SendCommand(command.CommandName, paramsNode, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);

            if (result == null)
                return null;

            if (!CommandResponseTypeMap.TryGetCommandResponseType<TCommand>(out Type commandResponseType))
                throw new InvalidOperationException($"Type {typeof(TCommand)} does not correspond to a known command response type.");

            return result.Deserialize(commandResponseType, opts) as ICommandResponse<TCommand>;
        }

        /// <summary>
        /// Sends the specified command and returns the associated command response.
        /// </summary>
        /// <typeparam name="TCommand"></typeparam
        /// <typeparam name="TCommandResponse"></typeparam>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <param name="throwExceptionIfResponseNotReceived"></param>
        /// <returns></returns>
        public async Task<TCommandResponse> SendCommand<TCommand, TCommandResponse>(TCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
            where TCommand : ICommand
            where TCommandResponse : ICommandResponse<TCommand>
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var opts = ChromeDevToolsJsonSerializerOptions.Instance;
            var paramsNode = JsonSerializer.SerializeToNode(command, command.GetType(), opts);
            var result = await SendCommand(command.CommandName, paramsNode, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);

            if (result == null)
                return default;

            return result.Deserialize<TCommandResponse>(opts);
        }

        private ConcurrentDictionary<long, TaskCompletionSource<ResponseInfo>> _messages = new();
        /// <summary>
        /// Returns a <see cref="JsonNode"/> for the "result" payload from a command with the specified name and params.
        /// </summary>
        /// <param name="commandName"></param>
        /// <param name="params"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <param name="throwExceptionIfResponseNotReceived"></param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        public virtual async Task<JsonNode> SendCommand(string commandName, JsonNode @params, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            var id = Interlocked.Increment(ref _currentCommandId);
            var message = new JsonObject
            {
                ["id"] = JsonValue.Create(id),
                ["method"] = JsonValue.Create(commandName),
                ["params"] = @params
            };

            if (millisecondsTimeout.HasValue == false)
                millisecondsTimeout = CommandTimeout;

            await OpenSessionConnection(cancellationToken);

            LogTrace("Sending {id} {method}: {params}", message["id"], message["method"], @params?.ToJsonString(ChromeDevToolsJsonSerializerOptions.Instance));

            var contents = message.ToJsonString(ChromeDevToolsJsonSerializerOptions.Instance);

            if (_isDisposed) return null;

            if (!throwExceptionIfResponseNotReceived)
            {
                TaskCompletionSource<ResponseInfo> fireAndForgetPromise = _messages.GetOrAdd(id, i => new TaskCompletionSource<ResponseInfo>(TaskCreationOptions.RunContinuationsAsynchronously));
                await SendTextMessage(contents, cancellationToken).ConfigureAwait(false);
                _ = AwaitAndRemoveFireAndForgetResponseAsync(id, fireAndForgetPromise);
                return null;
            }

            ResponseInfo res = null;
            try
            {
                TaskCompletionSource<ResponseInfo> promise = _messages.GetOrAdd(id, i => new TaskCompletionSource<ResponseInfo>(TaskCreationOptions.RunContinuationsAsynchronously));
                await SendTextMessage(contents, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();

                cancellationToken.Register(() => promise.TrySetCanceled(), false);

                res = await promise.Task.ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();

            }
            finally
            {
                _messages.TryRemove(id, out _);
            }

            if (res.IsError)
            {
                var errorMessage = GetErrorPropertyString(res.Result, "message");
                var errorData = GetErrorPropertyString(res.Result, "data");

                var exceptionMessage = $"{commandName}: {errorMessage}";
                if (!String.IsNullOrWhiteSpace(errorData))
                    exceptionMessage = $"{exceptionMessage} - {errorData}";

                LogTrace("Recieved Error Response {id}: {message} {data}", id, exceptionMessage, errorData);
                throw new CommandResponseException(exceptionMessage)
                {
                    Code = GetErrorPropertyInt64(res.Result, "code") ?? 0
                };
            }
            return res.Result;
        }

        private async Task AwaitAndRemoveFireAndForgetResponseAsync(long id, TaskCompletionSource<ResponseInfo> promise)
        {
            try
            {
                await promise.Task.ConfigureAwait(false);
            }
            catch
            {
            }
            finally
            {
                _messages.TryRemove(id, out _);
            }
        }

        static string GetErrorPropertyString(JsonNode errorNode, string name)
        {
            if (errorNode is not JsonObject err || !err.TryGetPropertyValue(name, out var n) || n == null)
                return null;
            if (n is JsonValue jv && jv.TryGetValue<string>(out var s))
                return s;
            return n.ToJsonString();
        }

        static long? GetErrorPropertyInt64(JsonNode errorNode, string name)
        {
            if (errorNode is not JsonObject err || !err.TryGetPropertyValue(name, out var n) || n is not JsonValue jv)
                return null;
            if (jv.TryGetValue<long>(out var l))
                return l;
            return null;
        }

        /// <summary>
        /// Subscribes to the event associated with the given type.
        /// </summary>
        /// <typeparam name="TEvent">Event to subscribe to</typeparam>
        /// <param name="eventCallback"></param>
        public virtual void Subscribe<TEvent>(Action<TEvent> eventCallback)
            where TEvent : IEvent
        {
            if (eventCallback == null)
                throw new ArgumentNullException(nameof(eventCallback));

            var eventName = _eventTypeMap.GetOrAdd(
                typeof(TEvent),
                (type) =>
                {
                    if (!EventTypeMap.TryGetMethodNameForType<TEvent>(out string methodName))
                        throw new InvalidOperationException($"Type {typeof(TEvent)} does not correspond to a known event type.");

                    return methodName;
                });

            var callbackWrapper = new Action<object>(obj => eventCallback((TEvent)obj));
            _eventHandlers.AddOrUpdate(eventName,
                (m) => [callbackWrapper],
                (m, currentBag) =>
                {
                    currentBag.Add(callbackWrapper);
                    return currentBag;
                });
        }

        private ClientWebSocket CreateSessionSocket()
        {
            var socket = new ClientWebSocket();
            socket.Options.KeepAliveInterval = Timeout.InfiniteTimeSpan;
            return socket;
        }

        private async Task OpenSessionConnection(CancellationToken cancellationToken)
        {
            if (_sessionSocket?.State == WebSocketState.Open)
                return;

            await _connectionSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (_sessionSocket?.State == WebSocketState.Open)
                    return;

                DisposeSessionSocket();

                var socket = CreateSessionSocket();
                _sessionSocket = socket;
                await socket.ConnectAsync(new Uri(_endpointAddress), cancellationToken).ConfigureAwait(false);

                var receiveLoopCancellationTokenSource = new CancellationTokenSource();
                _receiveLoopCancellationTokenSource = receiveLoopCancellationTokenSource;
                _receiveLoopTask = Task.Run(() => ReceiveMessages(socket, receiveLoopCancellationTokenSource.Token), cancellationToken);
            }
            finally
            {
                _connectionSemaphore.Release();
            }
        }

        private async Task SendTextMessage(string message, CancellationToken cancellationToken)
        {
            var socket = _sessionSocket;
            if (socket == null || socket.State != WebSocketState.Open)
                throw new InvalidOperationException("The websocket connection is not open.");

            var bytes = Encoding.UTF8.GetBytes(message);

            await _sendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _sendSemaphore.Release();
            }
        }

        private async Task ReceiveMessages(ClientWebSocket socket, CancellationToken cancellationToken)
        {
            var buffer = new byte[8192];
            var messageBuilder = new StringBuilder();

            try
            {
                while (!cancellationToken.IsCancellationRequested && socket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result;
                    do
                    {
                        result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken).ConfigureAwait(false);

                        if (result.MessageType == WebSocketMessageType.Close)
                            return;

                        if (result.MessageType == WebSocketMessageType.Text)
                            messageBuilder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
                    }
                    while (!result.EndOfMessage);

                    if (messageBuilder.Length == 0)
                        continue;

                    ProcessReceivedMessage(messageBuilder.ToString());
                    messageBuilder.Clear();
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
            }
            catch (Exception ex)
            {
                LogError("Error: {exception}", ex);
            }
        }

        private void RaiseEvent(string methodName, JsonNode eventData)
        {
            var opts = ChromeDevToolsJsonSerializerOptions.Instance;
            DevToolsEvent?.Invoke(this, methodName, eventData);
            if (_eventHandlers.TryGetValue(methodName, out ConcurrentBag<Action<Object>> bag))
            {
                if (!EventTypeMap.TryGetTypeForMethodName(methodName, out Type eventType))
                    throw new InvalidOperationException($"Unknown {methodName} does not correspond to a known event type.");

                object typedEventData = eventData.Deserialize(eventType, opts);
                foreach (var callback in bag)
                {
                    callback(typedEventData);
                }
            }
        }

        private void ProcessIncomingMessage(ResponseInfo response)
        {
            if (response.Result is not JsonObject messageObject) return;
            if (messageObject.TryGetPropertyValue("id", out JsonNode idProperty))
            {
                var res = new ResponseInfo();
                if (messageObject.TryGetPropertyValue("error", out JsonNode errorProperty))
                {
                    res.IsError = true;
                    res.Result = errorProperty;
                }
                else
                {
                    res.Result = messageObject["result"];
                }

                long commandId = idProperty is JsonValue idv && idv.TryGetValue<long>(out var lid) ? lid : 0;
                if (_messages.TryGetValue(commandId, out var promise))
                {
                    promise.SetResult(res);
                }
                else
                {
                    LogTrace("Ignoring unsolicited response {id}", commandId);
                }
                LogTrace("Recieved Response {id}: {message}", commandId, res.Result.ToJsonString(ChromeDevToolsJsonSerializerOptions.Instance));
                return;
            }

            if (messageObject.TryGetPropertyValue("method", out JsonNode methodProperty))
            {
                var method = methodProperty is JsonValue mv && mv.TryGetValue<string>(out var m) ? m : methodProperty?.ToString();
                var eventData = messageObject["params"];
                LogTrace("Recieved Event {method}: {params}", method, eventData?.ToJsonString(ChromeDevToolsJsonSerializerOptions.Instance));
                RaiseEvent(method, eventData);
                return;
            }

            //LogTrace("Recieved Other: {message}", message);
        }

        private void LogTrace(string message, params object[] args)
        {
            _logger?.LogTrace(message, args);
        }

        private void LogError(string message, params object[] args)
        {
            _logger?.LogError(message, args);
        }


        #region EventHandlers
        private void ProcessReceivedMessage(string message)
        {
            try
            {
                var responseInfo = new ResponseInfo { Result = JsonNode.Parse(message) };
                ProcessIncomingMessage(responseInfo);
            }
            catch
            {
                // ignored
            }
        }
        #endregion

        #region IDisposable Support
        private bool _isDisposed = false;

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    //Clear all subscribed events.
                    _eventHandlers.Clear();
                    _eventTypeMap.Clear();

                    DisposeSessionSocket();

                    _connectionSemaphore.Dispose();
                    _sendSemaphore.Dispose();

                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Disposes of the ChromeSession and frees all resources.
        ///</summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private void DisposeSessionSocket()
        {
            _receiveLoopCancellationTokenSource?.Cancel();
            _receiveLoopCancellationTokenSource?.Dispose();
            _receiveLoopCancellationTokenSource = null;
            _receiveLoopTask = null;

            _sessionSocket?.Dispose();
            _sessionSocket = null;
        }
        #endregion

        #region Nested Classes
        private class ResponseInfo
        {
            public bool IsError = false;
            public JsonNode Result;
        }
        #endregion
    }
}
