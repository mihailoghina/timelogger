using Xunit;
using Moq;
using Timelogger.Api.Repository;
using Timelogger.Entities;
using Timelogger.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace timelogger.tests
{
    public class UserControllerTests
    {
        [Fact]
        public void UserController_GetByIdTest()
        { 
            Guid guid = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5");

            var user = new User {
                Id = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    Email = "mihailoghina@gmail.com",
                    Name = "Mihai Loghina",
                    PathToAvatar = "https://scontent.ftsr1-2.fna.fbcdn.net/v/t31.0-8/30051625_2107799072784030_5121280528852449786_o.jpg?_nc_cat=109&_nc_oc=AQn4yaILHtPDILktZUJOzxf437jH9sgPORmE9aCj0ZUIEymNqRa3fJLUvRh1hmIiU8BMJ0bTB8h9krsU_B5fEpWd&_nc_ht=scontent.ftsr1-2.fna&oh=c65c675194d3b455f32274fcf8a41665&oe=5E2C7E61"
            };

            var mock = new Mock<IRepositoryWrapper>();
            mock.Setup( x => x.UserRepository.GetById(guid)).Returns(user);
            UsersController usersController = new UsersController(mock.Object);
            OkObjectResult result = usersController.GetUser(user.Id) as OkObjectResult;
            var actualUser = result.Value as User;
            Assert.Equal(user.Name, actualUser.Name);
            Assert.Equal(user.Email, actualUser.Email);
            Assert.Equal(user.PathToAvatar, actualUser.PathToAvatar);
        }
    }
}
