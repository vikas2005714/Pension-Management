using PensionerDetailMicroservice.Model;
using PensionerDetailMicroservice.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailMicroservice
{
    public class ApiResult
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public PensionDetailsDTO User { get; set; }
    }
}
