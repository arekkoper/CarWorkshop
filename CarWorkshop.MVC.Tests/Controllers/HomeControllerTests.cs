using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CarWorkshop.MVC.Controllers.Tests
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public HomeControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task About_ReturnsViewWithRenderModel()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync("/Home/About");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain("<h2>Some words about me</h2>")
                .And.Contain("<li>nice</li>");
        }
    }
}