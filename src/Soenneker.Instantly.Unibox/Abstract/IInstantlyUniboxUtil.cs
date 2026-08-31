using Soenneker.Instantly.OpenApiClient.Models;
using Soenneker.Instantly.Unibox.Requests;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Instantly.Unibox.Abstract;

/// <summary>
/// Lists Instantly Unibox emails using lead, campaign, type, preview, thread, and cursor filters.
/// </summary>
public interface IInstantlyUniboxUtil
{
    /// <summary>
    /// Gets a filtered page of Unibox emails.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The matching emails, or <see langword="null"/> when the API returns no body.</returns>
    ValueTask<List<Email>?> GetList(InstantlyEmailRequest request, CancellationToken cancellationToken = default);
}
