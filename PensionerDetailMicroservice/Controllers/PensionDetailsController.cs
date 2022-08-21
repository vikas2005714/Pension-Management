using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PensionerDetailMicroservice.IRepository;
using PensionerDetailMicroservice.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class PensionDetailsController : ControllerBase
    {
        private IPensionDetails _repository;
        private readonly ILogger<PensionDetailsController> _logger;


        public PensionDetailsController(IPensionDetails repository, ILogger<PensionDetailsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        [ActionName("PensionDetails")]
        [ProducesResponseType(200, Type = typeof(PensionDetailsDTO))]
        [ProducesResponseType(400)]
        public IActionResult GetPensionDetails(long Ano)
        {
            var apiresult = new ApiResult();
            _logger.LogInformation("Fething the User Details");
            try {
                var obj = _repository.GetPensionDetailsByAadar(Ano);
                if (obj == null) {
                    _logger.LogWarning("user Not Found");
                    apiresult.Message = "User Is Not Found For this Aadhar no. Please Check Aadhar again";
                    apiresult.Status = "Error";
                    apiresult.User = null;
                    return BadRequest(apiresult);
                }
                else {
                    apiresult.Message = "You Login Sucessfully";
                    apiresult.Status = "Success";
                    apiresult.User = obj;
                    return StatusCode(StatusCodes.Status200OK, apiresult.User);
                }
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }   

        }
    }
}
