using RectangleService.Core.Models;

namespace RectangleService.Core.Tests.Models
{
    /// <summary>
    /// UserTests
    /// </summary>
    public class UserTests
    {
        /// <summary>
        /// Users the default created on should be current date time.
        /// </summary>
        [Fact]
        public void User_DefaultCreatedOn_ShouldBeCurrentDateTime()
        {
            // Arrange
            var expectedDateTime = DateTime.Now;

            // Act
            var user = new User();

            // Assert
            Assert.Equal(expectedDateTime.Date, user.CreatedOn.Date);
            Assert.Equal(expectedDateTime.Hour, user.CreatedOn.Hour);
            Assert.Equal(expectedDateTime.Minute, user.CreatedOn.Minute);
        }

        /// <summary>
        /// Users the set first name should set first name property.
        /// </summary>
        [Fact]
        public void User_SetFirstName_ShouldSetFirstNameProperty()
        {
            // Arrange
            var user = new User();
            var expectedFirstName = "John";

            // Act
            user.FirstName = expectedFirstName;

            // Assert
            Assert.Equal(expectedFirstName, user.FirstName);
        }

        /// <summary>
        /// Users the set last name should set last name property.
        /// </summary>
        [Fact]
        public void User_SetLastName_ShouldSetLastNameProperty()
        {
            // Arrange
            var user = new User();
            var expectedLastName = "Doe";

            // Act
            user.LastName = expectedLastName;

            // Assert
            Assert.Equal(expectedLastName, user.LastName);
        }
    }
}
