namespace Zu.ChromeDevTools.Autofill
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Specified whether a filled field was done so by using the html autocomplete attribute or autofill heuristics.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FillingStrategy
    {
        [JsonStringEnumMemberName("autocompleteAttribute")]
        AutocompleteAttribute,
        [JsonStringEnumMemberName("autofillInferred")]
        AutofillInferred,
    }
}