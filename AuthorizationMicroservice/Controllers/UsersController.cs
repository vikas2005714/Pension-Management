using AuthorizationMicroservice.IRepository;
using AuthorizationMicroservice.Models;
using AuthorizationMicroservice.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace AuthorizationMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private IUser _repository;
        private readonly ILogger<UsersController> _logger;
        private readonly AppSettings _appSettings;


        public UsersController(IUser repository, ILogger<UsersController> logger, IOptions<AppSettings> appSetting)
        {
            _repository = repository;
            _logger = logger;
            _appSettings = appSetting.Value;
            

        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("UserLogin")]
        public ActionResult<ApiResult> Login([FromBody] UserDTO user)
        {
            var apiresult = new ApiResult();
            _logger.LogInformation("Enter in Login Methode");
            try {
                var users = _repository.FindUser_InList(user.UserName, user.Password);

                if(users == null) {
                    apiresult.Message = "User Is Not Found";
                    apiresult.Status = "Error";
                    apiresult.User = null;
                    return BadRequest(apiresult);
                }
                else {

                    var data = GetToken(users);
                    users.Token = data;
                    apiresult.Message = "You Login Sucessfully !";
                    apiresult.Status = "Success";
                    apiresult.User = users;
                    return StatusCode(StatusCodes.Status200OK, apiresult);
                }
            }
            catch(Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        private string GetToken(User user)
        {
            _logger.LogInformation("Generating the Token");
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokendescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokendescriptor);
            string tokendetails = tokenhandler.WriteToken(token);
            return tokendetails;
        }
    }
}
