using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPensionMicroservice.Model.DTO
{
        public class User
        {
            public string name { get; set; }
            public int pan { get; set; }
            public int aadharNo { get; set; }
            public int allowances { get; set; }
            public int salaryEarned { get; set; }
            public string pensionType { get; set; }
            public string bankName { get; set; }
            public int accountNo { get; set; }
            public string bankType { get; set; }
            public string dateOfBirth { get; set; }
        }
}
