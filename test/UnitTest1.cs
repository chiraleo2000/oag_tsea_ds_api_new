using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Controllers;

namespace SaoTsea.Ds.Api.Test
{
    public class SimpleTest : IClassFixture<ValuesController>
    {
        private readonly ValuesController _controller;

        public SimpleTest(ValuesController controller)
        {
            _controller = controller;
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
