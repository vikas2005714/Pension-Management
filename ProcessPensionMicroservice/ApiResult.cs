using ProcessPensionMicroservice.Model;
using ProcessPensionMicroservice.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPensionMicroservice
{
    public class ApiResult
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public ProcessPensionDTO User { get; set; }
    }
}
