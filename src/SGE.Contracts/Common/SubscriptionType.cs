using System.Text.Json.Serialization;

namespace SGE.Contracts.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionType
{
    Basic,
    Pro,
}