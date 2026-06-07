namespace Zu.ChromeDevTools.PWA
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Installs the given manifest identity, optionally using the given installUrlOrBundleUrl
    /// 
    /// IWA-specific install description:
    /// manifestId corresponds to isolated-app:// + web_package::SignedWebBundleId
    /// 
    /// File installation mode:
    /// The installUrlOrBundleUrl can be either file:// or http(s):// pointing
    /// to a signed web bundle (.swbn). In this case SignedWebBundleId must correspond to
    /// The .swbn file's signing key.
    /// 
    /// Dev proxy installation mode:
    /// installUrlOrBundleUrl must be http(s):// that serves dev mode IWA.
    /// web_package::SignedWebBundleId must be of type dev proxy.
    /// 
    /// The advantage of dev proxy mode is that all changes to IWA
    /// automatically will be reflected in the running app without
    /// reinstallation.
    /// 
    /// To generate bundle id for proxy mode:
    /// 1. Generate 32 random bytes.
    /// 2. Add a specific suffix at the end following the documentation
    ///    https://github.com/WICG/isolated-web-apps/blob/main/Scheme.md#suffix
    /// 3. Encode the entire sequence using Base32 without padding.
    /// 
    /// If Chrome is not in IWA dev
    /// mode, the installation will fail, regardless of the state of the allowlist.
    /// </summary>
    public sealed class InstallCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "PWA.install";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the manifestId
        /// </summary>
        [JsonPropertyName("manifestId")]
        public string ManifestId
        {
            get;
            set;
        }
        /// <summary>
        /// The location of the app or bundle overriding the one derived from the
        /// manifestId.
        /// </summary>
        [JsonPropertyName("installUrlOrBundleUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string InstallUrlOrBundleUrl
        {
            get;
            set;
        }
    }

    public sealed class InstallCommandResponse : ICommandResponse<InstallCommand>
    {
    }
}