using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Unibox.Responses;

public record InstantlyEmailData
{
    /// <summary>
    /// Email UUID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    /// <summary>
    /// Email message id
    /// </summary>
    [JsonPropertyName("message_id")]
    public string MessageId { get; set; } = default!;

    /// <summary>
    /// 1 = is unread; 0 = read
    /// </summary>
    [JsonPropertyName("is_unread")]
    public int IsUnread { get; set; }

    /// <summary>
    /// Lead's email associated with this email
    /// </summary>
    [JsonPropertyName("lead")]
    public string? Lead { get; set; }

    /// <summary>
    /// Campaign id associated with this email
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// Sender's email address
    /// </summary>
    [JsonPropertyName("from_address_email")]
    public string FromAddressEmail { get; set; } = default!;

    /// <summary>
    /// Sender's address details
    /// </summary>
    [JsonPropertyName("from_address_json")]
    public List<InstantlyEmailAddress>? FromAddressJson { get; set; }

    /// <summary>
    /// Subject
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Timestamp added to the database
    /// </summary>
    [JsonPropertyName("timestamp_created")]
    public string TimestampCreated { get; set; } = default!;

    /// <summary>
    /// Short content preview
    /// </summary>
    [JsonPropertyName("content_preview")]
    public string? ContentPreview { get; set; }

    /// <summary>
    /// Email body content
    /// </summary>
    [JsonPropertyName("body")]
    public InstantlyEmailBody? Body { get; set; }

    /// <summary>
    /// Thread id
    /// </summary>
    [JsonPropertyName("thread_id")]
    public string ThreadId { get; set; } = default!;

    /// <summary>
    /// Email account associated with this email
    /// </summary>
    [JsonPropertyName("eaccount")]
    public string EAccount { get; set; } = default!;

    /// <summary>
    /// To address email list
    /// </summary>
    [JsonPropertyName("to_address_email_list")]
    public string? ToAddressEmailList { get; set; }

    /// <summary>
    /// To address details
    /// </summary>
    [JsonPropertyName("to_address_json")]
    public List<InstantlyEmailAddress>? ToAddressJson { get; set; }

    /// <summary>
    /// Email type | 1 = sent from campaign; 2 = received; 3 = sent from Unibox
    /// </summary>
    [JsonPropertyName("ue_type")]
    public int UeType { get; set; }

    /// <summary>
    /// Scheduled at
    /// </summary>
    [JsonPropertyName("scheduled_at")]
    public string? ScheduledAt { get; set; }

    /// <summary>
    /// CC address email list
    /// </summary>
    [JsonPropertyName("cc_address_email_list")]
    public string? CcAddressEmailList { get; set; }

    /// <summary>
    /// CC address details
    /// </summary>
    [JsonPropertyName("cc_address_json")]
    public List<InstantlyEmailAddress>? CcAddressJson { get; set; }

    /// <summary>
    /// BCC address email list
    /// </summary>
    [JsonPropertyName("bcc_address_email_list")]
    public string? BccAddressEmailList { get; set; }
}