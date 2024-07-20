using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Unibox.Responses;

public record InstantlyEmailAddress
{
    /// <summary>
    /// Email address
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// AI interest value
    /// </summary>
    [JsonPropertyName("ai_interest_value")]
    public string? AiInterestValue { get; set; }

    /// <summary>
    /// Reminder timestamp
    /// </summary>
    [JsonPropertyName("reminder_ts")]
    public string? ReminderTs { get; set; }

    /// <summary>
    /// Interest status value
    /// </summary>
    [JsonPropertyName("i_status")]
    public string? IStatus { get; set; }
}