using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProcessPensionMicroservice.Data;
using ProcessPensionMicroservice.Model;
using ProcessPensionMicroservice.Model.DTO;
using ProcessPensionMicroservice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPensionMicroservice.Repository
{
    public class ProcessPensionRepository : IProcessPension
    {
        private readonly ApplicationDbContex db;
        private readonly IConfiguration configuration;
        private readonly IGetpensionDetails details;



        public ProcessPensionRepository(ApplicationDbContex _db, IConfiguration con,IGetpensionDetails _details)
        {
            db = _db;
            configuration = con;
            details = _details;

        }

        public ApiResult CalculatePension(long AadharNo)
        {
            var apiresult = new ApiResult();
            //var Httpreponse = new CallMicroservice(configuration);
            var pensionDetails = new ProcessPensionDTO();
            var response = details.HttpClientservice(AadharNo).Result;
            if (response.IsSuccessStatusCode && response.Content.ReadAsStringAsync().Result != "")
            {
                var result = response.Content.ReadAsStringAsync();
                User UserDetails = JsonConvert.DeserializeObject<User>(result.Result);
                pensionDetails.BankServiceCharge = (UserDetails.bankType == "Private") ? 550 : 500;
                double SelfAmount = 0.8 * (UserDetails.salaryEarned) + UserDetails.allowances;
                double FamilyAmount = 0.5 * (UserDetails.salaryEarned) + UserDetails.allowances;
                pensionDetails.PensionAmount = (UserDetails.pensionType == "Self") ? SelfAmount : FamilyAmount;
               // CreatePensionRecord(pensionDetails, AadharNo);
                apiresult.Message = "You Login Sucessfully";
                apiresult.Status = "Success";
                apiresult.User = pensionDetails;
                return apiresult;
            }

            apiresult.Message = "User Is Not Found For this Aadhar no. Please Check Aadhar again";
            apiresult.Status = "Error";
            apiresult.User = null;
            return apiresult;
        }

        public bool CreatePensionRecord(ProcessPensionDTO pension,long Ano)
        {
            var PensionDetails = new ProcessPension() {
                PensionAmount = pension.PensionAmount,
                BankServiceCharge = pension.BankServiceCharge,
                AddharId = Ano
            };

            if(db.processPensions.Where(x => x.AddharId == PensionDetails.AddharId).Any())
            {
                var pensionrecord = db.processPensions.Where(u => u.AddharId == PensionDetails.AddharId).SingleOrDefault();
                pensionrecord.PensionAmount = PensionDetails.PensionAmount;
                pensionrecord.BankServiceCharge = PensionDetails.BankServiceCharge;
                db.SaveChanges();
                return true;
            }
            db.processPensions.Add(PensionDetails);
            db.SaveChanges();
            return true;
        }
    }
}
