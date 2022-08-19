using PensionerDetailMicroservice.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailMicroservice.IRepository
{
    public interface IPensionDetails
    {
        PensionDetailsDTO GetPensionDetailsByAadar(long AadharNo);
    }
}
