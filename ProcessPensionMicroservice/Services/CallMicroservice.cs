using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProcessPensionMicroservice.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ProcessPensionMicroservice.Services
{
    public class CallMicroservice: IGetpensionDetails
    {
        public string pensiondetailsurl { get; set; }
        public readonly IHttpContextAccessor _httpContextAccessor;
        public CallMicroservice(IConfiguration config,IHttpContextAccessor httpContextAccessor)
        {
            pensiondetailsurl = config.GetSection("pensiondetailsUrl").Value;
            _httpContextAccessor = httpContextAccessor;

        }
        public  async Task<User> HttpClientservice(long Ano)
        {
            User UserDetails = null;
            try
            {
                HttpContext httpContext = _httpContextAccessor.HttpContext;
                var authenticationInfo = await httpContext.AuthenticateAsync();
                string token = authenticationInfo.Properties.GetTokenValue("access_token");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(pensiondetailsurl);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                 HttpResponseMessage responseMessage = await client.GetAsync("api/PensionDetails/PensionDetails?Ano=" + Ano);
                if(responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync();
                    UserDetails = JsonConvert.DeserializeObject<User>(result.Result);

                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Unable to Fetch data from api",ex);
            }

            return UserDetails;
        }
    }
}
