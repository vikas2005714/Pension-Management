using AuthorizationMicroservice;
using AuthorizationMicroservice.Data;
using AuthorizationMicroservice.IRepository;
using AuthorizationMicroservice.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContex db;
        private readonly AppSettings _appSettings;

        public UserRepository(ApplicationDbContex _db,IOptions<AppSettings> appSetting )
        {
            db = _db;
            _appSettings = appSetting.Value;


        }
        
        public User FindUser_InList(string username, string password)
        {
            var user = db.users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            return user;
        }
    }
}
