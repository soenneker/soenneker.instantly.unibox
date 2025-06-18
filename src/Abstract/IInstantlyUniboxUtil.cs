using Soenneker.Instantly.OpenApiClient.Models;
using Soenneker.Instantly.Unibox.Requests;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Instantly.Unibox.Abstract;

/// <summary>
/// A .NET typesafe implementation of Instantly's Unibox API
/// </summary>
public interface IInstantlyUniboxUtil
{
    ValueTask<List<Def2>?> GetList(InstantlyEmailRequest request, CancellationToken cancellationToken = default);
}