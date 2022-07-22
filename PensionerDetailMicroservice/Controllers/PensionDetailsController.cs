using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionerDetailMicroservice.IRepository;
using PensionerDetailMicroservice.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PensionDetailsController : ControllerBase
    {
        private IPensionDetails _repository;


        public PensionDetailsController(IPensionDetails repository)
        {
            _repository = repository;


        }


        [HttpGet]
        [ActionName("PensionDetails")]
        [ProducesResponseType(200, Type = typeof(PensionDetailsDTO))]
        [ProducesResponseType(400)]
        public IActionResult GetNationalPark(long Ano)
        {
            try {
                var data = _repository.GetPensionDetailsByAadar(Ano);
                return StatusCode(StatusCodes.Status200OK, data.User);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }   

        }
    }
}
