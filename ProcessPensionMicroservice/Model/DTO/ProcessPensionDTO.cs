using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPensionMicroservice.Model.DTO
{
    public class ProcessPensionDTO
    {
        public double PensionAmount { get; set; }
        public int BankServiceCharge { get; set; }
    }
}
