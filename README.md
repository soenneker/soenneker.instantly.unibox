[![](https://img.shields.io/nuget/v/soenneker.instantly.unibox.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.instantly.unibox/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.instantly.unibox/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.instantly.unibox/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.instantly.unibox.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.instantly.unibox/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.instantly.unibox/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.instantly.unibox/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Instantly.Unibox

List Instantly Unibox emails filtered by lead, campaign, direction, preview mode, thread, or pagination cursor.

## Install

```bash
dotnet add package Soenneker.Instantly.Unibox
```

## Configure and register

```json
{
  "Instantly": {
    "ApiKey": "<API key>",
    "LogEnabled": false
  }
}
```

```csharp
using Soenneker.Instantly.Unibox.Registrars;

services.AddInstantlyUniboxUtilAsScoped();
```

The scoped Unibox service deliberately uses the singleton generated-client provider. Use `AddInstantlyUniboxUtilAsSingleton()` when the operation layer should also live for the application lifetime.

## Usage

```csharp
using Soenneker.Instantly.OpenApiClient.Models;
using Soenneker.Instantly.Unibox.Abstract;
using Soenneker.Instantly.Unibox.Requests;

var request = new InstantlyEmailRequest
{
    CampaignId = campaignId,
    Lead = "person@example.com",
    EmailType = ListEmailEmailTypeParameter.Received,
    PreviewOnly = true,
    LatestOfThread = true,
    PageTrail = startingAfter
};

List<Email>? emails = await unibox.GetList(
    request,
    cancellationToken);
```

All filters are optional:

- `CampaignId` and `Lead` narrow the mailbox results.
- `EmailType` accepts `Received`, `Sent`, or `Manual`.
- `SentEmails = true` is a convenience for `EmailType = Sent`; an explicit `EmailType` takes precedence.
- `PreviewOnly = true` requests previews instead of full message bodies.
- `LatestOfThread = true` returns only the latest email in each thread.
- `PageTrail` is sent as Instantly's `starting_after` cursor.

`GetList` returns only the response `Items`; it does not expose `next_starting_after` or automatically paginate. Use the generated client directly when the next cursor is required.

API failures are surfaced to the caller. A nullable result means Instantly returned no response body.
