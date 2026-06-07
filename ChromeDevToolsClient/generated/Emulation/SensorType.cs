namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Used to specify sensor types to emulate.
    /// See https://w3c.github.io/sensors/#automation for more information.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SensorType
    {
        [JsonStringEnumMemberName("absolute-orientation")]
        AbsoluteOrientation,
        [JsonStringEnumMemberName("accelerometer")]
        Accelerometer,
        [JsonStringEnumMemberName("ambient-light")]
        AmbientLight,
        [JsonStringEnumMemberName("gravity")]
        Gravity,
        [JsonStringEnumMemberName("gyroscope")]
        Gyroscope,
        [JsonStringEnumMemberName("linear-acceleration")]
        LinearAcceleration,
        [JsonStringEnumMemberName("magnetometer")]
        Magnetometer,
        [JsonStringEnumMemberName("relative-orientation")]
        RelativeOrientation,
    }
}