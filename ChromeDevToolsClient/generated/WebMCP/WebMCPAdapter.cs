namespace Zu.ChromeDevTools.WebMCP
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an adapter for the WebMCP domain to simplify the command interface.
    /// </summary>
    public partial class WebMCPAdapter
    {
        private readonly ChromeSession m_session;
        
        public WebMCPAdapter(ChromeSession session)
        {
            m_session = session ?? throw new ArgumentNullException(nameof(session));
        }

        /// <summary>
        /// Gets the ChromeSession associated with the adapter.
        /// </summary>
        public ChromeSession Session
        {
            get { return m_session; }
        }

        /// <summary>
        /// Enables the WebMCP domain, allowing events to be sent. Enabling the domain will trigger a toolsAdded event for
        /// all currently registered tools.
        /// </summary>
        public async Task<EnableCommandResponse> Enable(EnableCommand command = null, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<EnableCommand, EnableCommandResponse>(command ?? new EnableCommand(), cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Disables the WebMCP domain.
        /// </summary>
        public async Task<DisableCommandResponse> Disable(DisableCommand command = null, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<DisableCommand, DisableCommandResponse>(command ?? new DisableCommand(), cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Invokes a registered tool.
        /// </summary>
        public async Task<InvokeToolCommandResponse> InvokeTool(InvokeToolCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<InvokeToolCommand, InvokeToolCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Cancels a pending tool invocation.
        /// </summary>
        public async Task<CancelInvocationCommandResponse> CancelInvocation(CancelInvocationCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<CancelInvocationCommand, CancelInvocationCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }

        /// <summary>
        /// Event fired when new tools are added.
        /// </summary>
        public void SubscribeToToolsAddedEvent(Action<ToolsAddedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Event fired when tools are removed.
        /// </summary>
        public void SubscribeToToolsRemovedEvent(Action<ToolsRemovedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Event fired when a tool invocation starts.
        /// </summary>
        public void SubscribeToToolInvokedEvent(Action<ToolInvokedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Event fired when a tool invocation completes or fails.
        /// </summary>
        public void SubscribeToToolRespondedEvent(Action<ToolRespondedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
    }
}