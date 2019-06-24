using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using UsersManagement.ServiceLibrary.Common.Contracts;
using UsersManagement.ServiceLibrary.Common.Dtos;
using UsersManagement.UI.Controllers;
using UsersManagement.UI.Models.Users;

namespace UsersManagement.UI.Tests.Controllers
{
    [TestClass]
    public class UsersControllerShould
    {
        private readonly Mock<IUserService> _userServiceMock;
        private UsersController _usersController;

        private IEnumerable<UserDto> _listOfUsersDtoMock;
        private readonly UserDto _userDtoMock1;
        private readonly UserDto _userDtoMock2;

        public UsersControllerShould()
        {
            _userServiceMock = new Mock<IUserService>();
            _usersController = new UsersController(_userServiceMock.Object);
            _usersController.Request = new HttpRequestMessage();
            _usersController.Configuration = new HttpConfiguration();

            _userDtoMock1 = new UserDto
            {
                Id = Guid.NewGuid().ToString(),
                Username = "oriol",
                Password = "oriol",
                Roles = new List<string> { "Admin" }
            };
            _userDtoMock2 = new UserDto
            {
                Id = Guid.NewGuid().ToString(),
                Username = "puig",
                Password = "puig",
                Roles = new List<string> { "Admin" }
            };
            _listOfUsersDtoMock = new List<UserDto> { _userDtoMock1, _userDtoMock2 };
        }

        [TestMethod]
        public void return_list_of_users_on_GET()
        {
            _userServiceMock.Setup(u => u.GetAllUsers()).Returns(_listOfUsersDtoMock);
            var response = _usersController.Get() as OkNegotiatedContentResult<IEnumerable<UserViewModel>>;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.IsTrue(response.Content.Any());
        }

        [TestMethod]
        public void return_a_user_on_GET()
        {
            _userServiceMock.Setup(u => u.GetUser(_userDtoMock1.Id)).Returns(_userDtoMock1);
            var response = _usersController.Get(_userDtoMock1.Id) as OkNegotiatedContentResult<UserViewModel>;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.IsTrue(response.Content.Id == _userDtoMock1.Id);
        }

        [TestMethod]
        public void return_a_new_user_on_POST()
        {
            var newUserVM = new UserViewModel { Username = "test", Password = "test", Roles = new List<string> { "Admin" } };
            var createdUserDto = new UserDto
            {
                Id = Guid.NewGuid().ToString(),
                Username = newUserVM.Username,
                Password = newUserVM.Password,
                Roles = newUserVM.Roles
            };

            _userServiceMock.Setup(u => u.CreateUser(It.IsAny<UserDto>())).Returns(createdUserDto);
            var response = _usersController.Post(newUserVM) as OkNegotiatedContentResult<UserViewModel>;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.IsTrue(response.Content.Id == createdUserDto.Id);
        }

        [TestMethod]
        public void return_a_true_on_UPDATE()
        {
            var userIdToUpdate = Guid.NewGuid().ToString();
            var userVMToUpdate = new UserViewModel
            {
                Id = userIdToUpdate,
                Username = "test",
                Password = "test",
                Roles = new List<string> { "Admin" }
            };
            var userToUpdate = new UserDto
            {
                Id = userVMToUpdate.Id,
                Username = userVMToUpdate.Username,
                Password = userVMToUpdate.Password,
                Roles = userVMToUpdate.Roles
            };

            _userServiceMock.Setup(u => u.UpdateUser(userIdToUpdate, It.IsAny<UserDto>())).Returns(true);
            var response = _usersController.Put(userIdToUpdate, userVMToUpdate) as OkResult;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Request);
            Assert.IsNull(response.Request.Content);
        }

        [TestMethod]
        public void return_a_true_on_DELETE()
        {
            var userIdToDelete = Guid.NewGuid().ToString();
            _userServiceMock.Setup(u => u.DeleteUser(userIdToDelete)).Returns(true);
            var response = _usersController.Delete(userIdToDelete) as OkResult;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Request);
            Assert.IsNull(response.Request.Content);
        }
    }
}
