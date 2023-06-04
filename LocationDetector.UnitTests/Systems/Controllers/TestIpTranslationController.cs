using LocationDetector.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LocationDetector.UnitTests.Systems.Controllers;

public class TestIpTranslationController
{
    [Fact]
    public async Task Post_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange
        var sut = new IpTranslationController();

        // Act
        var result = (OkObjectResult)await sut.Post();

        // Assert
        result.StatusCode.Equals(200);
    }
}