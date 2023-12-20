using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ShelfLayoutManager.Api.Controllers;
using ShelfLayoutManager.Core.Application.Cabinets;
using ShelfLayoutManager.Core.Domain.Cabinets;

namespace ShelfLayoutManager.Test.Api
{
    public class CabinetControllerTest
    {
        private readonly Mock<ILogger<CabinetController>> _mockLogger;
        private readonly Mock<ICabinetApplication> _mockApplication;
        private readonly CabinetController _controller;

        public CabinetControllerTest()
        {
            _mockLogger = new Mock<ILogger<CabinetController>>();
            _mockApplication = new Mock<ICabinetApplication>();
            _controller = new CabinetController(_mockLogger.Object, _mockApplication.Object);
        }

        [Fact]
        public async Task Get_ReturnsAllCabinets()
        {
            // Arrange
            var mockCabinets = new List<Cabinet> { new Cabinet(), new Cabinet() };
            _mockApplication.Setup(app => app.GetCabinets()).ReturnsAsync(mockCabinets);

            // Act
            var result = await _controller.Get();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Cabinet>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetCabinetByNumber_ReturnsCabinet()
        {
            // Arrange
            int cabinetNumber = 1;
            var mockCabinet = new Cabinet { Number = cabinetNumber };
            _mockApplication.Setup(app => app.GetCabinetByNumber(It.IsAny<int>())).ReturnsAsync(mockCabinet);

            // Act
            var result = await _controller.Get(cabinetNumber);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Cabinet>(actionResult.Value);
            Assert.Equal(cabinetNumber, returnValue.Number);
        }

        // Testes adicionais para Create, Update e Delete podem ser estruturados de maneira semelhante
    }
}
