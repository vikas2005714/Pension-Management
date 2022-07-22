using ProcessPensionMicroservice.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPensionMicroservice.Model
{
    public class ProcessPension
    {
        [Key]
        public int Id { get; set; }
        public double PensionAmount { get; set; }
        public int BankServiceCharge { get; set; }
        public long AddharId { get; set; }

    }
}
