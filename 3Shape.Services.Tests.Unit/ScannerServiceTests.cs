using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _3Shape.Contracts;
using _3Shape.Domain.Entities;
using _3Shape.Domain.Repositories;
using _3Shape.Services.Abstractions;
using FluentAssertions;
using Moq;
using Xunit;

namespace _3Shape.Services.Tests.Unit;

public class ScannerServiceTests
{
    /*
    §  Receive images from the scanner and forward them to the reconstruction engine.

    §  Return the currently reconstructed model from the reconstruction engine, e.g., "1oene2enoe3neoo4aei5iia" described in the introduction.

   

    §  Get the geometry of a specific tooth from a reconstructed model. E.g. return "1oene" when the upper right molar furthest in the back is requested.

    §  Create a case to be sent to a lab with a tooth marked for a specific restoration.
    */
    
    private readonly Mock<IReconstructionEngineRepository> _repoMock = new Mock<IReconstructionEngineRepository>();
    private readonly Mock<IUnitOfWork> _UoWMock = new Mock<IUnitOfWork>();

    [Fact]
    public async Task GetReconstructionTest()
    {
        // Arrange
        _repoMock.Reset();
        const string expectedInitialScan = "1abcde2zxcvb3mnbvc"; 
        const string expectedNewScan = "bvc4ed";
        const string expectedScan = "1abcde2zxcvb3mnbvc4ed";

        IScannerService service = new ScannerService(_repoMock.Object, _UoWMock.Object);

        var entity = new ReconstructionEntity(
            Guid.NewGuid(), 
            expectedInitialScan);

        _repoMock
            .Setup(x => x.Get(It.Is<Guid>(x => x == entity.Id)))
            .ReturnsAsync(entity);

        // Act
        var actual = await service.AddScan(entity.Id, new AddStepDto(expectedNewScan));

        // Assert
        actual.Should().NotBeNull();
        actual.Image.Should().Be(expectedScan);
    }
}