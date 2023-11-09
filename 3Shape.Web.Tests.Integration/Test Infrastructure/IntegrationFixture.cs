using System.Threading.Tasks;
using Xunit;

namespace _3Shape.Web.Tests.Integration;

public sealed class IntegrationFixture : IAsyncLifetime
{
    // do fixture stuff
    public Task DisposeAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task InitializeAsync()
    {
        throw new System.NotImplementedException();
    }
}