using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProcessPensionMicroservice.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProcessPensionMicroservice.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ProcessPensionController : ControllerBase
    {
        private IProcessPension _repository;
        private readonly ILogger<ProcessPensionController> _logger;
        public ProcessPensionController(IProcessPension repository, ILogger<ProcessPensionController> logger)
        {
            _repository = repository;
            _logger = logger;


        }
       
        [HttpPost]
        [ActionName("ProcessPensionDetails")]
        //[ProducesResponseType(200, Type = typeof(PensionDetailsDTO))]
        [ProducesResponseType(400)]
        public IActionResult PensionCalculation([FromBody] AddharInput Ano)
        {
            _logger.LogInformation("Calculating the Pension Amounts");
            try
            {
                var data = _repository.CalculatePension(Ano.AddharNo);
                return StatusCode(StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in the Calcualting the Pension");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

    }
}
