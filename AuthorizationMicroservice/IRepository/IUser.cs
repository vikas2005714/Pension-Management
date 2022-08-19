using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationMicroservice.Models;

namespace AuthorizationMicroservice.IRepository
{
    public interface IUser
    {
        User FindUser_InList(string username, string password);
    }
}
