using Soenneker.Instantly.Unibox.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Instantly.Unibox.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class InstantlyUniboxUtilTests : HostedUnitTest
{
    private readonly IInstantlyUniboxUtil _util;

    public InstantlyUniboxUtilTests(Host host) : base(host)
    {
        _util = Resolve<IInstantlyUniboxUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
