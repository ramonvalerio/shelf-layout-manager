using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ShelfLayoutManager.Api.Controllers;
using ShelfLayoutManager.Core.Application.Cabinets;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Exceptions;

namespace ShelfLayoutManager.Test.Api
{
    public class CabinetControllerTest
    {
        private readonly Mock<ILogger<CabinetController>> _mockLogger;
        private readonly Mock<ICabinetRepository> _mockCabinetRepository;
        private readonly Mock<ICabinetService> _mockCabinetService;
        private readonly CabinetController _controller;

        public CabinetControllerTest()
        {
            _mockLogger = new Mock<ILogger<CabinetController>>();
            _mockCabinetRepository = new Mock<ICabinetRepository>();
            _mockCabinetService = new Mock<ICabinetService>();

            var application = new CabinetApplication(_mockCabinetRepository.Object, _mockCabinetService.Object);

            _controller = new CabinetController(_mockLogger.Object, application);
        }

        [Fact]
        public async Task Get_ReturnsAllCabinets()
        {
            // Arrange
            var mockCabinets = new List<Cabinet> { new Cabinet(), new Cabinet() };
            _mockCabinetRepository.Setup(app => app.GetAllAsync()).ReturnsAsync(mockCabinets);

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
            _mockCabinetRepository.Setup(app => app.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(mockCabinet);

            // Act
            var result = await _controller.Get(cabinetNumber);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Cabinet>(actionResult.Value);
            Assert.Equal(cabinetNumber, returnValue.Number);
        }

        [Fact]
        public async Task CreateCabinetWith_ExistentNumber()
        {
            // Arrange
            var command = new CreateCabinetCommand
            {
                Number = 1,
                X = 4,
                Y = 5,
                Z = 6,
                Width = 7,
                Height = 8,
                Depth = 9
            };

            int cabinetExistentNumber = 3;
            var mockCabinet = new Cabinet { Number = cabinetExistentNumber };
            var exceptionMessage = $"Cabinet number {command.Number} already exist.";
            _mockCabinetRepository.Setup(app => app.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(mockCabinet);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _controller.Create());
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public async Task CreateCabinet_SuccessfulCreation()
        {
            //var position = new Position { X = command.X, Y = command.Y, Z = command.Z };
            //var size = new Size { Width = command.Width, Height = command.Height, Depth = command.Depth };
            //var newCabinet = new Cabinet(command.Number, position, size);

            _mockCabinetRepository.Setup(app => app.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Cabinet)null);
            //_mockCabinetRepository.Setup(app => app.Create(It.IsAny<Cabinet>())).ReturnsAsync(newCabinet);

            // Act
            var result = await _controller.Create();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Cabinet>(actionResult.Value);
            //Assert.Equal(newCabinet, returnValue);
        }
    }
}
