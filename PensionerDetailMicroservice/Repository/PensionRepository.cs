using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public PensionDetailsDTO GetPensionDetailsByAadar(long AadharNo)
        {
            var user = db.pensiondetail.Include(i => i.BankDetail).SingleOrDefault(x => x.AadharNo == AadharNo);
            var obj = _mapper.Map<PensionDetailsDTO>(user);
            obj.BankName = user.BankDetail.BankName;
            return obj;
           
        }
    }
}
