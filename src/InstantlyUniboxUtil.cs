using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Instantly.Unibox.Abstract;
using System.Threading.Tasks;
using System.Threading;
using Soenneker.Instantly.Unibox.Requests;
using Soenneker.Extensions.Enumerable;
using Soenneker.Instantly.ClientUtil.Abstract;
using Soenneker.Instantly.OpenApiClient.Api.V2.Emails;
using System;
using Soenneker.Instantly.OpenApiClient;
using Soenneker.Extensions.ValueTask;
using System.Collections.Generic;
using Soenneker.Instantly.OpenApiClient.Models;
using Soenneker.Extensions.Task;

namespace Soenneker.Instantly.Unibox;

/// <inheritdoc cref="IInstantlyUniboxUtil"/>
public sealed class InstantlyUniboxUtil : IInstantlyUniboxUtil
{
    private readonly IInstantlyOpenApiClientUtil _instantlyClient;
    private readonly ILogger<InstantlyUniboxUtil> _logger;

    private readonly bool _log;

    public InstantlyUniboxUtil(IInstantlyOpenApiClientUtil instantlyClient, ILogger<InstantlyUniboxUtil> logger, IConfiguration config)
    {
        _instantlyClient = instantlyClient;
        _logger = logger;

        _log = config.GetValue<bool>("Instantly:LogEnabled");
    }

    public async ValueTask<List<Def2>?> GetList(InstantlyEmailRequest request, CancellationToken cancellationToken = default)
    {
        if (_log && request.CampaignId.Populated())
            _logger.LogDebug("Getting emails from Instantly... Campaign: {campaign}, Lead: {lead}", request.CampaignId, request.Lead);

        InstantlyOpenApiClient client = await _instantlyClient.Get(cancellationToken).NoSync();

        EmailsGetResponse? response = await client.Api.V2.Emails.GetAsEmailsGetResponseAsync(config =>
        {
            if (request.CampaignId.Populated())
                config.QueryParameters.CampaignId = Guid.Parse(request.CampaignId);

            if (request.Lead.Populated())
                config.QueryParameters.Lead = request.Lead;

            if (request.PreviewOnly.HasValue)
                config.QueryParameters.PreviewOnly = request.PreviewOnly.Value;

            if (request.EmailType != null)
                config.QueryParameters.EmailTypeAsGetEmailTypeQueryParameterType = request.EmailType.Value;

            if (request.PageTrail.Populated())
                config.QueryParameters.StartingAfter = request.PageTrail;
        }, cancellationToken).NoSync();

        if (response == null)
            return null;

        return response.Items;

    }
}