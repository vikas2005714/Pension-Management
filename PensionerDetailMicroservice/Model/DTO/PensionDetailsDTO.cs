using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailMicroservice.Model.DTO
{
    public class PensionDetailsDTO
    {
        public string Name { get; set; }
        public long PAN { get; set; }
        public long AadharNo { get; set; }
        public int Allowances { get; set; }
        public int SalaryEarned { get; set; }
        public string PensionType { get; set; }
        public string BankName { get; set; }
        public long AccountNo { get; set; }
        public string BankType { get; set; }
        public string DateOfBirth { get; set; }
    }
}
