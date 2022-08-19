using ProcessPensionMicroservice.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProcessPensionMicroservice.Services
{
    public interface IGetpensionDetails
    {
        Task<User> HttpClientservice(long Ano);
    }
}
