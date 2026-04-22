using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.Auth.RolesPrincipalFactory.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class RolesPrincipalFactoryTests : HostedUnitTest
{

    public RolesPrincipalFactoryTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
