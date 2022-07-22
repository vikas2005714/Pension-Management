using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using PensionerDetailMicroservice.Model;
using PensionerDetailMicroservice.Model.DTO;

namespace PensionerDetailMicroservice.AutoMapper
{
    public class PensionDetailsMapper : Profile
    {
        public PensionDetailsMapper()
        {
            CreateMap<PensionDetails, PensionDetailsDTO>().ReverseMap();
        }
        
    }
}
