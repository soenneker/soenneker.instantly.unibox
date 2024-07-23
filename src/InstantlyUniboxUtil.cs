using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Configuration;
using Soenneker.Instantly.Client.Abstract;
using Soenneker.Instantly.Unibox.Abstract;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Soenneker.Extensions.HttpClient;
using Soenneker.Extensions.ValueTask;
using Soenneker.Instantly.Unibox.Requests;
using Soenneker.Instantly.Unibox.Responses;
using Soenneker.Extensions.Enumerable;
using Soenneker.Extensions.Object;
using Soenneker.Instantly.Client;

namespace Soenneker.Instantly.Unibox;

/// <inheritdoc cref="IInstantlyUniboxUtil"/>
public class InstantlyUniboxUtil : IInstantlyUniboxUtil
{
    private readonly IInstantlyClient _instantlyClient;
    private readonly ILogger<InstantlyUniboxUtil> _logger;

    private readonly string _apiKey;
    private readonly bool _log;

    public InstantlyUniboxUtil(IInstantlyClient instantlyClient, ILogger<InstantlyUniboxUtil> logger, IConfiguration config)
    {
        _instantlyClient = instantlyClient;
        _logger = logger;

        _apiKey = config.GetValueStrict<string>("Instantly:ApiKey");
        _log = config.GetValue<bool>("Instantly:LogEnabled");
    }

    public async ValueTask<InstantlyEmailResponse?> GetList(InstantlyEmailRequest request, CancellationToken cancellationToken = default)
    {
        if (_log && request.CampaignId.Populated())
            _logger.LogDebug("Getting emails from Instantly... Campaign: {campaign}, Lead: {lead}", request.CampaignId, request.Lead);

        if (request.ApiKey.IsNullOrEmpty())
            request.ApiKey = _apiKey;

        HttpClient client = await _instantlyClient.Get(cancellationToken).NoSync();

        string uri = InstantlyClient.BaseUri + "unibox/emails" + request.ToQueryString();

        InstantlyEmailResponse? response = await client.SendWithRetryToType<InstantlyEmailResponse>(HttpMethod.Get, uri, request, cancellationToken: cancellationToken).NoSync();

        return response;
    }
}