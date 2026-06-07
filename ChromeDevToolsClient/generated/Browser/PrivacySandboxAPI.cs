namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PrivacySandboxAPI
    {
        [JsonStringEnumMemberName("BiddingAndAuctionServices")]
        BiddingAndAuctionServices,
        [JsonStringEnumMemberName("TrustedKeyValue")]
        TrustedKeyValue,
    }
}