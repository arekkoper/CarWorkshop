using Xunit;
using CarWorkshop.Application.CarWorkshopService.Commands;
using Moq;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using FluentAssertions;
using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Commands.Tests
{
    public class CreateCarWorkshopServiceCommandHandlerTests
    {
        [Fact()]
        public async Task Handle_CreateCarWorkshopService_WhenUserIsAuthorized()
        {
            //arrange
            var carWorkshop = new Domain.Entities.CarWorkshop()
            {
                Id = 1,
                CreatedById = "1"
            };

            var command = new CreateCarWorkshopServiceCommand()
            {
                Cost = "100",
                Description = "Wymiana opon",
                CarWorkshopEncodedName = "car-workshop"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser()).Returns(new CurrentUser("1", "test@test.com", new[] { "User" }));

            var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
            carWorkshopRepositoryMock.Setup(r => r.GetByEncodedName(command.CarWorkshopEncodedName)).ReturnsAsync(carWorkshop);

            var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRespository>();

            var handler = new CreateCarWorkshopServiceCommandHandler(userContextMock.Object, carWorkshopRepositoryMock.Object, carWorkshopServiceRepositoryMock.Object);

            //act
            var result = await handler.Handle(command, CancellationToken.None);

            //assert
            result.Should().Be(Unit.Value);
            carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Once);
        }
        
        
        [Fact()]
        public async Task Handle_CreateCarWorkshopService_WhenUserIsModerator()
        {
            //arrange
            var carWorkshop = new Domain.Entities.CarWorkshop()
            {
                Id = 1,
                CreatedById = "1"
            };

            var command = new CreateCarWorkshopServiceCommand()
            {
                Cost = "100",
                Description = "Wymiana opon",
                CarWorkshopEncodedName = "car-workshop"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser()).Returns(new CurrentUser("2", "test@test.com", new[] { "Moderator" }));

            var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
            carWorkshopRepositoryMock.Setup(r => r.GetByEncodedName(command.CarWorkshopEncodedName)).ReturnsAsync(carWorkshop);

            var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRespository>();

            var handler = new CreateCarWorkshopServiceCommandHandler(userContextMock.Object, carWorkshopRepositoryMock.Object, carWorkshopServiceRepositoryMock.Object);

            //act
            var result = await handler.Handle(command, CancellationToken.None);

            //assert
            result.Should().Be(Unit.Value);
            carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Once);
        }   
        

        [Fact()]
        public async Task Handle_DoesntCreateCarWorkshopService_WhenUserIsNotAuthorized()
        {
            //arrange
            var carWorkshop = new Domain.Entities.CarWorkshop()
            {
                Id = 1,
                CreatedById = "1"
            };

            var command = new CreateCarWorkshopServiceCommand()
            {
                Cost = "100",
                Description = "Wymiana opon",
                CarWorkshopEncodedName = "car-workshop"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser()).Returns(new CurrentUser("2", "test@test.com", new[] { "User" }));

            var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
            carWorkshopRepositoryMock.Setup(r => r.GetByEncodedName(command.CarWorkshopEncodedName)).ReturnsAsync(carWorkshop);

            var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRespository>();

            var handler = new CreateCarWorkshopServiceCommandHandler(userContextMock.Object, carWorkshopRepositoryMock.Object, carWorkshopServiceRepositoryMock.Object);

            //act
            var result = await handler.Handle(command, CancellationToken.None);

            //assert
            result.Should().Be(Unit.Value);
            carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Never);
        }        

        [Fact()]
        public async Task Handle_DoesntCreateCarWorkshopService_WhenUserIsNotAuthenticated()
        {
            //arrange
            var carWorkshop = new Domain.Entities.CarWorkshop()
            {
                Id = 1,
                CreatedById = "1"
            };

            var command = new CreateCarWorkshopServiceCommand()
            {
                Cost = "100",
                Description = "Wymiana opon",
                CarWorkshopEncodedName = "car-workshop"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser()).Returns((CurrentUser?)null);

            var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
            carWorkshopRepositoryMock.Setup(r => r.GetByEncodedName(command.CarWorkshopEncodedName)).ReturnsAsync(carWorkshop);

            var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRespository>();

            var handler = new CreateCarWorkshopServiceCommandHandler(userContextMock.Object, carWorkshopRepositoryMock.Object, carWorkshopServiceRepositoryMock.Object);

            //act
            var result = await handler.Handle(command, CancellationToken.None);

            //assert
            result.Should().Be(Unit.Value);
            carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Never);
        }
    }
}