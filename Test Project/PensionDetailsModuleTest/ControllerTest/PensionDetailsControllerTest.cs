using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using PensionerDetailMicroservice;
using PensionerDetailMicroservice.Controllers;
using PensionerDetailMicroservice.Data;
using PensionerDetailMicroservice.IRepository;
using PensionerDetailMicroservice.Model;
using PensionerDetailMicroservice.Model.DTO;
using PensionerDetailMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionDetailsModuleTest.ControllerTest
{
    [TestFixture]
    public class PensionDetailsControllerTest
    {
        //private readonly IConfiguration _configuration;
        private readonly Mock<ILogger<PensionDetailsController>> _loggerMock;
        private readonly Mock<IPensionDetails> _PensionDetailsRepositoryMock;
        private readonly PensionDetailsController PensionDetailsController;

        public PensionDetailsControllerTest()
        {
            _loggerMock = new Mock<ILogger<PensionDetailsController>>();
            _PensionDetailsRepositoryMock = new Mock<IPensionDetails>();
            PensionDetailsController = new PensionDetailsController(_PensionDetailsRepositoryMock.Object, _loggerMock.Object);
        }

        [Test]
        public void PensionerDetailByAadhaar_ReturnsPensioner_WhenCorrectAadhaar()
        {
            long aadhaarNumber = 12345;
            _PensionDetailsRepositoryMock.Setup(i => i.GetPensionDetailsByAadar(aadhaarNumber)).Returns(GetPensionerByAadhaarHelper());

            //Act
            var actionResult =  PensionDetailsController.GetPensionDetails(aadhaarNumber);
            var actionResultValue = (PensionDetailsDTO)((ObjectResult)actionResult).Value;

            //Assert  
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResultValue.BankName,"SBI");
            Assert.IsInstanceOf<PensionDetailsDTO>(actionResultValue);
        }

        [Test]
        public void PensionerDetailByAadhaar_ReturnsPensioner_WhenInCorrectAadhaar()
        {
            long aadhaarNumber = 0000;
            _PensionDetailsRepositoryMock.Setup(i => i.GetPensionDetailsByAadar(aadhaarNumber)).Returns((GetPensionerForInCorrectAadhaarHelper()));

            //Act
            var actionResult = PensionDetailsController.GetPensionDetails(aadhaarNumber);
            var actionResultValue = (ApiResult)((ObjectResult)actionResult).Value;

            //Assert  
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResultValue.Message, "User Is Not Found For this Aadhar no. Please Check Aadhar again");
            Assert.AreEqual(actionResultValue.Status, "Error");

        }

        public static PensionDetailsDTO GetPensionerByAadhaarHelper()
        {
            var details = new PensionDetailsDTO()
            {
                Name = "Vikas",
                DateOfBirth = "31/12/1998",
                PAN = 12345,
                AadharNo = 12345,
                AccountNo = 968557297810,
                SalaryEarned = 11111,
                Allowances = 1200,
                PensionType = "Family",
                BankName = "SBI",
                BankType = "public"

            };
            return details;
        }

        public static PensionDetailsDTO GetPensionerForInCorrectAadhaarHelper()
        {
            var details = new PensionDetailsDTO();  
            return details = null;
        }

    }
}
