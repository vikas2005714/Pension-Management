using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ProcessPensionMicroservice;
using ProcessPensionMicroservice.Controllers;
using ProcessPensionMicroservice.Data;
using ProcessPensionMicroservice.Model.DTO;
using ProcessPensionMicroservice.Repository;
using ProcessPensionMicroservice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProcessPensionModuleTest.ControllerTest
{
    [TestFixture]
    public class ProcessPensionControllerTest
    {
        private readonly Mock<ILogger<ProcessPensionController>> _loggerMock;
        private readonly ProcessPensionRepository ProcessPensionRepositoryMock;
        private readonly ProcessPensionController ProcessPensionController;
        private readonly Mock<IGetpensionDetails> PensionDetails;
        private readonly ApplicationDbContex db;

        public ProcessPensionControllerTest()
        {
            _loggerMock = new Mock<ILogger<ProcessPensionController>>();
            PensionDetails = new Mock<IGetpensionDetails>();
            db = ProcessPensionconfig.GetApplicationDbContext();
            ProcessPensionRepositoryMock = new ProcessPensionRepository(db, PensionDetails.Object);
            ProcessPensionController = new ProcessPensionController(ProcessPensionRepositoryMock, _loggerMock.Object);
        }

        [Test]
        public void CalculatePensionByAadhaar_ReturnsPension_WhenCorrectAadhaar()
        {
            var aadhaarNumber = new AddharInput() { AddharNo = 12345 };
            long AddharNo = 12345;
            PensionDetails.Setup(i => i.HttpClientservice(AddharNo)).Returns(apistatus());
            //Act
            var actionResult = ProcessPensionController.PensionCalculation(aadhaarNumber);
            var actionResultValue = (ApiResult)((ObjectResult)actionResult).Value;

            //Assert  
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResultValue.Message, "Your Amount Calculate Sucessfully");
            Assert.AreEqual(actionResultValue.Status,"Success");
            Assert.AreEqual(actionResultValue.User.PensionAmount,10600);
            Assert.AreEqual(actionResultValue.User.BankServiceCharge,550);
            
        }

        [Test]
        public void CalculatePensionByAadhaar_ReturnsPension_ForIncorrectAadhaar()
        {
            var aadhaarNumber = new AddharInput() { AddharNo = 0123 };
            long AddharNo = 0123;
            PensionDetails.Setup(i => i.HttpClientservice(AddharNo)).Returns(UserdetailsForIncorrectAdhaar());
            //Act
            var actionResult = ProcessPensionController.PensionCalculation(aadhaarNumber);
            var actionResultValue = (ApiResult)((ObjectResult)actionResult).Value;

            //Assert  
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResultValue.Message, "User Is Not Found For this Aadhar no. Please Check Aadhar again");
            Assert.AreEqual(actionResultValue.Status, "Error");
           
        }

        public async Task<User> apistatus()
        {
            var userdetails = new User()
            {
                name = "vikas",
                pan = 12345,
                aadharNo = 12345,
                bankName = "SBI",
                bankType = "Private",
                salaryEarned = 12000,
                allowances = 1000,
                pensionType = "Self"

            };
            return userdetails;

        }

        public async Task<User> UserdetailsForIncorrectAdhaar()
        {
            var userdetails = new User();      
            return userdetails = null;

        }

    }
}
