using Xunit;
using CarWorkshop.Application.ApplicationUser;
using FluentAssertions;

namespace CarWorkshop.Application.ApplicationUser.Tests
{
    public class CurrentUserTests
    {
        [Fact()]
        public void IsInRole_WithMatchingRoleShouldReturnTrue()
        {
            //arrange
            var currentUser = new CurrentUser("1", "test@test.com", new List<string>(){ "Admin", "User" });

            //act
            var isInRole = currentUser.IsInRole("Admin");

            //assert
            isInRole.Should().BeTrue();
        }
        
        [Fact()]
        public void IsInRole_WithNonMatchingRoleShouldReturnFalse()
        {
            //arrange
            var currentUser = new CurrentUser("1", "test@test.com", new List<string>(){ "Admin", "User" });

            //act
            var isInRole = currentUser.IsInRole("Manager");

            //assert
            isInRole.Should().BeFalse();
        }

        [Fact()]
        public void IsInRole_WithNonMatchingCaseRoleShouldReturnFalse()
        {
            //arrange
            var currentUser = new CurrentUser("1", "test@test.com", new List<string>() { "Admin", "User" });

            //act
            var isInRole = currentUser.IsInRole("admin");

            //assert
            isInRole.Should().BeFalse();
        }
    }
}