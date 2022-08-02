using Microsoft.Extensions.Configuration;
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
        public CallMicroservice(IConfiguration config)
        {
            pensiondetailsurl = config.GetSection("pensiondetailsUrl").Value;

        }
        public  Task<HttpResponseMessage> HttpClientservice(long Ano)
        {
            //string BASE_URL = "https://localhost:44394/";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(pensiondetailsurl);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client.GetAsync("api/PensionDetails/PensionDetails?Ano=" + Ano);
            }
            catch(Exception ex)
            {
                throw new ArgumentException("fde", ex);
            }
        }
    }
}
