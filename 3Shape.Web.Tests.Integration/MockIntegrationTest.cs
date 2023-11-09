using FluentAssertions;
using Xunit;

namespace _3Shape.Web.Tests.Integration;

public class MockIntegrationTest // : fixtures (IAssemblyFixtures etc.)
{
    [Fact]
    public void POST_CreateReconstruction_InsertsIntoDb_WhenImageDoesNotAlreadyExist()
    {
        // Arrange
        // Add things to db, set up any necessary mocks
        // Set up http client, requests etc
        // Act 
        // var response = client.SendAsync(request..)
        // Assert
        // do assertions

        var x = true;

        x.Should().BeTrue();
    }
}