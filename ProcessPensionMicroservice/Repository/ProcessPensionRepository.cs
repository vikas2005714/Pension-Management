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
        private readonly IGetpensionDetails details;



        public ProcessPensionRepository(ApplicationDbContex _db, IGetpensionDetails _details)
        {
            db = _db;
            details = _details;

        }

        public ApiResult CalculatePension(long AadharNo)
        {
            var apiresult = new ApiResult();
            var pensionDetails = new ProcessPensionDTO();
            var UserDetails = details.HttpClientservice(AadharNo).Result;
            if(UserDetails != null)
            {

                pensionDetails.BankServiceCharge = (UserDetails.bankType == "Private") ? 550 : 500;
                double SelfAmount = 0.8 * (UserDetails.salaryEarned) + UserDetails.allowances;
                double FamilyAmount = 0.5 * (UserDetails.salaryEarned) + UserDetails.allowances;
                pensionDetails.PensionAmount = (UserDetails.pensionType == "Self") ? SelfAmount : FamilyAmount;
               // CreatePensionRecord(pensionDetails, AadharNo);
                apiresult.Message = "Your Amount Calculate Sucessfully";
                apiresult.Status = "Success";
                apiresult.User = pensionDetails;
                return apiresult;
            }
            apiresult.Message = "User Is Not Found For this Aadhar no. Please Check Aadhar again";
            apiresult.Status = "Error";
            apiresult.User = null;
            return apiresult;
        }
    }
}
