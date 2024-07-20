using Ardalis.SmartEnum.SystemTextJson;
using Soenneker.Instantly.Unibox.Enums;
using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Unibox.Requests;

public class InstantlyEmailRequest
{
    /// <summary>
    /// Your API Key
    /// </summary>
    [JsonPropertyName("api_key")]
    public string ApiKey { get; set; } = default!;

    /// <summary>
    /// Set to false if you only want the email content's preview and not the full body
    /// </summary>
    [JsonPropertyName("preview_only")]
    public bool? PreviewOnly { get; set; }

    /// <summary>
    /// Email address of lead (optional) - only fetch emails for a specific lead
    /// </summary>
    [JsonPropertyName("lead")]
    public string? Lead { get; set; }

    /// <summary>
    /// Campaign id (optional) - only fetch emails for a specific campaign
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// Set to true if you only want to fetch sent emails
    /// </summary>
    [JsonPropertyName("sent_emails")]
    public bool? SentEmails { get; set; }

    /// <summary>
    /// Email type
    /// </summary>
    [JsonPropertyName("email_type")]
    [JsonConverter(typeof(SmartEnumNameConverter<InstantlyEmailType, int>))]
    public InstantlyEmailType? EmailType { get; set; }

    /// <summary>
    /// Set to true if you want to only fetch the latest email per thread
    /// </summary>
    [JsonPropertyName("latest_of_thread")]
    public bool? LatestOfThread { get; set; }

    /// <summary>
    /// Used for pagination - returned in the response
    /// </summary>
    [JsonPropertyName("page_trail")]
    public string? PageTrail { get; set; }
}