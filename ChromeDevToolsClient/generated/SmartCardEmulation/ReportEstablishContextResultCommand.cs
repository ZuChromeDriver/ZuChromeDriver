namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Reports the successful result of a |SCardEstablishContext| call.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaa1b8970169fd4883a6dc4a8f43f19b67
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardestablishcontext
    /// </summary>
    public sealed class ReportEstablishContextResultCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "SmartCardEmulation.reportEstablishContextResult";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the requestId
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the contextId
        /// </summary>
        [JsonPropertyName("contextId")]
        public long ContextId
        {
            get;
            set;
        }
    }

    public sealed class ReportEstablishContextResultCommandResponse : ICommandResponse<ReportEstablishContextResultCommand>
    {
    }
}