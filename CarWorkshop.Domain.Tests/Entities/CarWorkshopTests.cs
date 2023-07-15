using Xunit;
using CarWorkshop.Domain.Entities;
using FluentAssertions;

namespace CarWorkshop.Domain.Entities.Tests
{
    public class CarWorkshopTests
    {
        [Fact()]
        public void EncodeName_ShouldSetEncodedName()
        {
            //arrange
            var carWorkshop = new CarWorkshop();
            carWorkshop.Name = "Test CarWorkshop";

            //act
            carWorkshop.EncodeName();

            //assert
            carWorkshop.EncodedName.Should().Be("test-carworkshop");
        }

        [Fact]
        public void EncodeName_ShouldThrowExeptionWhenNameIsNull()
        {
            //arrange
            var carWorkshop = new CarWorkshop();

            //act
            Action action = () => carWorkshop.EncodeName();

            //assert
            action.Invoking(a => a.Invoke()).Should().Throw<NullReferenceException>();
        }
    }
}