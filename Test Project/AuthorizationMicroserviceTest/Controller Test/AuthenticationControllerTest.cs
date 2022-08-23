using AuthorizationMicroservice;
using AuthorizationMicroservice.Controllers;
using AuthorizationMicroservice.IRepository;
using AuthorizationMicroservice.Models;
using AuthorizationMicroservice.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;


namespace AuthorizationMicroserviceTest.Controller_Test
{
    [TestFixture]
    public class AuthenticationControllerTest
    {
        private readonly Mock<ILogger<UsersController>> _loggerMock;
        private readonly Mock<IUser> _UserRepositoryMock;
        private readonly UsersController usersController;
        private readonly IOptions<AppSettings> _appSettings;

        public AuthenticationControllerTest()
        {
            _loggerMock = new Mock<ILogger<UsersController>>();
            _UserRepositoryMock = new Mock<IUser>();
            _appSettings = Options.Create(new AppSettings() { Secret = "SE10125779374235322" });
            usersController = new UsersController(_UserRepositoryMock.Object, _loggerMock.Object,_appSettings);

        }

        [Test]
        public void UsersLogin_Succefully()
        {
            var users = new User()
            {
                Id = 1,
                UserName = "Vikas",
                Password = "Vikas",
                Token = null
            };
           


            _UserRepositoryMock.Setup(i => i.FindUser_InList("Vikas", "Vikas")).Returns(UserDetails());
           
            //Arrange
             var user = new UserDTO()
             {
                 UserName = "Vikas",
                 Password = "Vikas"
             };
            var actionResult = usersController.Login(user);
            //var abc = actionResult.Result;
            
            var actionResultValue = (ApiResult)((ObjectResult)actionResult.Result).Value;
            string Message = actionResultValue.Message;
            string status = actionResultValue.Status;
            var userinfo = actionResultValue.User;

            Assert.IsNotNull(users);
            Assert.AreEqual("Success", status);
            Assert.AreEqual("You Login Sucessfully !", Message);


        }

        [Test]
        public void UsersLogin_Failed()
        {
            _UserRepositoryMock.Setup(i => i.FindUser_InList("", "")).Returns(UserDetailsNotFound());

            var user = new UserDTO()
            {
                UserName = null,
                Password = null
            };

            var actionResult = usersController.Login(user);
            //var abc = actionResult.Result;

            var actionResultValue = (AuthorizationMicroservice.ApiResult)((BadRequestObjectResult)actionResult.Result).Value;
            string Message = actionResultValue.Message;
            string status = actionResultValue.Status;
            var users = actionResultValue.User;

            Assert.IsNull(users);
            Assert.AreEqual("Error", status);
            Assert.AreEqual("User Is Not Found", Message);

        }
        public static User UserDetails()
        {
            var user = new User()
            {
                Id = 1,
                UserName = "Vikas",
                Password = "Vikas"
            };
            return user;
        }

        public static User UserDetailsNotFound()
        {
            var user = new User();
            user = null;
            return user;
        }

        public static ApiResult SuccesfullLogin()
        {
            var result = new ApiResult()
            {
                Message = "Success",
                Status = "You Login Sucessfully !",
                User = new User
                {
                    Id = 1,
                    UserName = "vikas",
                    Password = "vikas"
                }
            };

            return result;

        }
    }
}
