using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Unibox.Responses;

public record InstantlyEmailBody
{
    /// <summary>
    /// The text content of the email body. May or may not be present depending on the actual email's content.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// The HTML content of the email body. May or may not be present depending on the actual email's content.
    /// </summary>
    [JsonPropertyName("html")]
    public string? Html { get; set; }
}