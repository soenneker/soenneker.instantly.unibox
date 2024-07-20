using Soenneker.Facts.Local;
using Soenneker.Instantly.Unibox.Abstract;
using Soenneker.Tests.FixturedUnit;
using System.Threading.Tasks;
using Soenneker.Instantly.Unibox.Enums;
using Soenneker.Instantly.Unibox.Requests;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Instantly.Unibox.Tests;

[Collection("Collection")]
public class InstantlyUniboxUtilTests : FixturedUnitTest
{
    private readonly IInstantlyUniboxUtil _util;

    public InstantlyUniboxUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IInstantlyUniboxUtil>(true);
    }

    [LocalFact]
    public async Task GetList_should_get_list()
    {
        var request = new InstantlyEmailRequest
        {
            Lead = "",
            EmailType = InstantlyEmailType.Received,
            PreviewOnly = false
        };

        var emails = await _util.GetList(request);
    }
}