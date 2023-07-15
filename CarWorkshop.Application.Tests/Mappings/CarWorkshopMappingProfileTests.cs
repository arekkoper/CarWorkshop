using Xunit;
using CarWorkshop.Application.Mappings;
using Moq;
using CarWorkshop.Application.ApplicationUser;
using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using FluentAssertions;

namespace CarWorkshop.Application.Mappings.Tests
{
    public class CarWorkshopMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapCarWorkshopDtoToCarWorkshop()
        {
            //arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser()).Returns(new CurrentUser("1", "test@test.com", new[] { "User" }));

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var dto = new CarWorkshopDTO()
            {
                City = "Wałcz",
                PhoneNumber = "321654987",
                PostalCode = "70-600",
                Adress = "Wąska 3/1"
            };

            //act
            var result = mapper.Map<Domain.Entities.CarWorkshop>(dto);

            //assert
            result.Should().NotBeNull();
            result.ContactDetails.City.Should().Be(dto.City);
            result.ContactDetails.PhoneNumber.Should().Be(dto.PhoneNumber);
            result.ContactDetails.PostalCode.Should().Be(dto.PostalCode);
            result.ContactDetails.Adress.Should().Be(dto.Adress);

        }
    }
}