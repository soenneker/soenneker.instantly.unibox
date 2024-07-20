using Soenneker.Instantly.Unibox.Requests;
using Soenneker.Instantly.Unibox.Responses;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Instantly.Unibox.Abstract;

/// <summary>
/// A .NET typesafe implementation of Instantly's Unibox API
/// </summary>
public interface IInstantlyUniboxUtil
{
    ValueTask<InstantlyEmailResponse?> GetList(InstantlyEmailRequest request, CancellationToken cancellationToken = default);
}