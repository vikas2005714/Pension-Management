using AutoMapper;
using PensionerDetailMicroservice.Data;
using PensionerDetailMicroservice.IRepository;
using PensionerDetailMicroservice.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailMicroservice.Repository
{
    public class PensionRepository : IPensionDetails
    {
        private readonly ApplicationDbContex db;
        private readonly IMapper _mapper;


        public PensionRepository(ApplicationDbContex _db, IMapper mapper)
        {
            db = _db;
            _mapper = mapper;
           

        }
        public ApiResult GetPensionDetailsByAadar(long AadharNo)
        {
            var apiresult = new ApiResult();
            var user = db.pensiondetail.SingleOrDefault(x => x.AadharNo == AadharNo);
            var obj = _mapper.Map<PensionDetailsDTO>(user);
            if (obj == null)
            {
                apiresult.Message = "User Is Not Found For this Aadhar no. Please Check Aadhar once again";
                apiresult.Status = "Error";
                apiresult.User = null;
                return apiresult;
            }
            apiresult.Message = "You Login Sucessfully";
            apiresult.Status = "Success";
            apiresult.User = obj;
            return apiresult;
        }
    }
}
