namespace Zu.ChromeDevTools.CrashReportContext
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an adapter for the CrashReportContext domain to simplify the command interface.
    /// </summary>
    public partial class CrashReportContextAdapter
    {
        private readonly ChromeSession m_session;
        
        public CrashReportContextAdapter(ChromeSession session)
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
        /// Returns all entries in the CrashReportContext across all frames in the page.
        /// </summary>
        public async Task<GetEntriesCommandResponse> GetEntries(GetEntriesCommand command = null, CancellationToken cancellationToken = default, int? millisecondsTimeout = null, bool throwExceptionIfResponseNotReceived = true)
        {
            return await m_session.SendCommand<GetEntriesCommand, GetEntriesCommandResponse>(command ?? new GetEntriesCommand(), cancellationToken, millisecondsTimeout, throwExceptionIfResponseNotReceived);
        }

    }
}