using Soenneker.Instantly.Unibox.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Instantly.Unibox.Tests;

[Collection("Collection")]
public class InstantlyUniboxUtilTests : FixturedUnitTest
{
    private readonly IInstantlyUniboxUtil _util;

    public InstantlyUniboxUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IInstantlyUniboxUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
