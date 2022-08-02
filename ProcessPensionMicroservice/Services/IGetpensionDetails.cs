using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProcessPensionMicroservice.Services
{
    public interface IGetpensionDetails
    {
        Task<HttpResponseMessage> HttpClientservice(long Ano);
    }
}
