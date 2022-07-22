using PensionerDetailMicroservice.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailMicroservice.IRepository
{
    public interface IPensionDetails
    {
        ApiResult GetPensionDetailsByAadar(long AadharNo);
    }
}
