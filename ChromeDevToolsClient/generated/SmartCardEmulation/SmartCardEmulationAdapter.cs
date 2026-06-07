namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an adapter for the SmartCardEmulation domain to simplify the command interface.
    /// </summary>
    public partial class SmartCardEmulationAdapter
    {
        private readonly ChromeSession m_session;
        
        public SmartCardEmulationAdapter(ChromeSession session)
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
        /// Enables the |SmartCardEmulation| domain.
        /// </summary>
        public async Task<EnableCommandResponse> Enable(EnableCommand command = null, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<EnableCommand, EnableCommandResponse>(command ?? new EnableCommand(), cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Disables the |SmartCardEmulation| domain.
        /// </summary>
        public async Task<DisableCommandResponse> Disable(DisableCommand command = null, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<DisableCommand, DisableCommandResponse>(command ?? new DisableCommand(), cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Reports the successful result of a |SCardEstablishContext| call.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaa1b8970169fd4883a6dc4a8f43f19b67
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardestablishcontext
        /// </summary>
        public async Task<ReportEstablishContextResultCommandResponse> ReportEstablishContextResult(ReportEstablishContextResultCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<ReportEstablishContextResultCommand, ReportEstablishContextResultCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Reports the successful result of a |SCardReleaseContext| call.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga6aabcba7744c5c9419fdd6404f73a934
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardreleasecontext
        /// </summary>
        public async Task<ReportReleaseContextResultCommandResponse> ReportReleaseContextResult(ReportReleaseContextResultCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<ReportReleaseContextResultCommand, ReportReleaseContextResultCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Reports the successful result of a |SCardListReaders| call.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga93b07815789b3cf2629d439ecf20f0d9
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlistreadersa
        /// </summary>
        public async Task<ReportListReadersResultCommandResponse> ReportListReadersResult(ReportListReadersResultCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<ReportListReadersResultCommand, ReportListReadersResultCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Reports the successful result of a |SCardGetStatusChange| call.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga33247d5d1257d59e55647c3bb717db24
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetstatuschangea
        /// </summary>
        public async Task<ReportGetStatusChangeResultCommandResponse> ReportGetStatusChangeResult(ReportGetStatusChangeResultCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<ReportGetStatusChangeResultCommand, ReportGetStatusChangeResultCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Reports the result of a |SCardBeginTransaction| call.
        /// On success, this creates a new transaction object.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaddb835dce01a0da1d6ca02d33ee7d861
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardbegintransaction
        /// </summary>
        public async Task<ReportBeginTransactionResultCommandResponse> ReportBeginTransactionResult(ReportBeginTransactionResultCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<ReportBeginTransactionResultCommand, ReportBeginTransactionResultCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Reports the successful result of a call that returns only a result code.
        /// Used for: |SCardCancel|, |SCardDisconnect|, |SCardSetAttrib|, |SCardEndTransaction|.
        /// 
        /// This maps to:
        /// 1. SCardCancel
        ///    PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaacbbc0c6d6c0cbbeb4f4debf6fbeeee6
        ///    Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardcancel
        /// 
        /// 2. SCardDisconnect
        ///    PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga4be198045c73ec0deb79e66c0ca1738a
        ///    Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scarddisconnect
        /// 
        /// 3. SCardSetAttrib
        ///    PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga060f0038a4ddfd5dd2b8fadf3c3a2e4f
        ///    Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardsetattrib
        /// 
        /// 4. SCardEndTransaction
        ///    PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gae8742473b404363e5c587f570d7e2f3b
        ///    Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardendtransaction
        /// </summary>
        public async Task<ReportPlainResultCommandResponse> ReportPlainResult(ReportPlainResultCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<ReportPlainResultCommand, ReportPlainResultCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Reports the successful result of a |SCardConnect| call.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga4e515829752e0a8dbc4d630696a8d6a5
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardconnecta
        /// </summary>
        public async Task<ReportConnectResultCommandResponse> ReportConnectResult(ReportConnectResultCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<ReportConnectResultCommand, ReportConnectResultCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Reports the successful result of a call that sends back data on success.
        /// Used for |SCardTransmit|, |SCardControl|, and |SCardGetAttrib|.
        /// 
        /// This maps to:
        /// 1. SCardTransmit
        ///    PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga9a2d77242a271310269065e64633ab99
        ///    Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardtransmit
        /// 
        /// 2. SCardControl
        ///    PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gac3454d4657110fd7f753b2d3d8f4e32f
        ///    Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardcontrol
        /// 
        /// 3. SCardGetAttrib
        ///    PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaacfec51917255b7a25b94c5104961602
        ///    Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetattrib
        /// </summary>
        public async Task<ReportDataResultCommandResponse> ReportDataResult(ReportDataResultCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<ReportDataResultCommand, ReportDataResultCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Reports the successful result of a |SCardStatus| call.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gae49c3c894ad7ac12a5b896bde70d0382
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardstatusa
        /// </summary>
        public async Task<ReportStatusResultCommandResponse> ReportStatusResult(ReportStatusResultCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<ReportStatusResultCommand, ReportStatusResultCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }
        /// <summary>
        /// Reports an error result for the given request.
        /// </summary>
        public async Task<ReportErrorCommandResponse> ReportError(ReportErrorCommand command, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<ReportErrorCommand, ReportErrorCommandResponse>(command, cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }

        /// <summary>
        /// Fired when |SCardEstablishContext| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaa1b8970169fd4883a6dc4a8f43f19b67
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardestablishcontext
        /// </summary>
        public void SubscribeToEstablishContextRequestedEvent(Action<EstablishContextRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardReleaseContext| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga6aabcba7744c5c9419fdd6404f73a934
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardreleasecontext
        /// </summary>
        public void SubscribeToReleaseContextRequestedEvent(Action<ReleaseContextRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardListReaders| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga93b07815789b3cf2629d439ecf20f0d9
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlistreadersa
        /// </summary>
        public void SubscribeToListReadersRequestedEvent(Action<ListReadersRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardGetStatusChange| is called. Timeout is specified in milliseconds.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga33247d5d1257d59e55647c3bb717db24
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetstatuschangea
        /// </summary>
        public void SubscribeToGetStatusChangeRequestedEvent(Action<GetStatusChangeRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardCancel| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaacbbc0c6d6c0cbbeb4f4debf6fbeeee6
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardcancel
        /// </summary>
        public void SubscribeToCancelRequestedEvent(Action<CancelRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardConnect| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga4e515829752e0a8dbc4d630696a8d6a5
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardconnecta
        /// </summary>
        public void SubscribeToConnectRequestedEvent(Action<ConnectRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardDisconnect| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga4be198045c73ec0deb79e66c0ca1738a
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scarddisconnect
        /// </summary>
        public void SubscribeToDisconnectRequestedEvent(Action<DisconnectRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardTransmit| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga9a2d77242a271310269065e64633ab99
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardtransmit
        /// </summary>
        public void SubscribeToTransmitRequestedEvent(Action<TransmitRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardControl| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gac3454d4657110fd7f753b2d3d8f4e32f
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardcontrol
        /// </summary>
        public void SubscribeToControlRequestedEvent(Action<ControlRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardGetAttrib| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaacfec51917255b7a25b94c5104961602
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetattrib
        /// </summary>
        public void SubscribeToGetAttribRequestedEvent(Action<GetAttribRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardSetAttrib| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga060f0038a4ddfd5dd2b8fadf3c3a2e4f
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardsetattrib
        /// </summary>
        public void SubscribeToSetAttribRequestedEvent(Action<SetAttribRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardStatus| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gae49c3c894ad7ac12a5b896bde70d0382
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardstatusa
        /// </summary>
        public void SubscribeToStatusRequestedEvent(Action<StatusRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardBeginTransaction| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaddb835dce01a0da1d6ca02d33ee7d861
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardbegintransaction
        /// </summary>
        public void SubscribeToBeginTransactionRequestedEvent(Action<BeginTransactionRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
        /// <summary>
        /// Fired when |SCardEndTransaction| is called.
        /// 
        /// This maps to:
        /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gae8742473b404363e5c587f570d7e2f3b
        /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardendtransaction
        /// </summary>
        public void SubscribeToEndTransactionRequestedEvent(Action<EndTransactionRequestedEvent> eventCallback)
        {
            m_session.Subscribe(eventCallback);
        }
    }
}