using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Unibox.Responses;

public record InstantlyEmailResponse
{
    /// <summary>
    /// Used for pagination - you can pass this on to fetch the next page
    /// </summary>
    [JsonPropertyName("page_trail")]
    public string? PageTrail { get; set; }

    /// <summary>
    /// Data array containing email details
    /// </summary>
    [JsonPropertyName("data")]
    public List<InstantlyEmailData>? Data { get; set; }
}