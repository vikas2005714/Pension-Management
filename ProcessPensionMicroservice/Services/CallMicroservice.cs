using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ProcessPensionMicroservice.Services
{
    public class CallMicroservice
    {
        public  Task<HttpResponseMessage> HttpClientservice(long Ano)
        {
            string BASE_URL = "https://localhost:44394/";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
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
