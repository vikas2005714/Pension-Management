using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ProcessPensionController(IProcessPension repository)
        {
            _repository = repository;


        }
       
        [HttpPost]
        [ActionName("ProcessPensionDetails")]
        //[ProducesResponseType(200, Type = typeof(PensionDetailsDTO))]
        [ProducesResponseType(400)]
        public IActionResult GetNationalPark([FromBody] AddharInput Ano)
        {
            try
            {
                var data = _repository.CalculatePension(Ano.AddharNo);
                return StatusCode(StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

    }
}
