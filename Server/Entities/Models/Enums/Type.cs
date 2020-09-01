using System.Text.Json.Serialization;

namespace Entities.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Type
    {
        Road,
        Mountain
    }
}