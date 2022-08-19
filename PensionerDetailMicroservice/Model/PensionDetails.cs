using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailMicroservice.Model
{
    public class PensionDetails
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public long PAN { get; set; }
        [Required]
        public long AadharNo { get; set; }
        public int Allowances { get; set; }
        public int SalaryEarned { get; set; }
        public string PensionType { get; set; }
       // public string BankName { get; set; }
        public long AccountNo { get; set; }
        public string BankType { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        public int BankId { get; set; }
        [ForeignKey("BankId")]
        public BankList BankDetail { get; set; }
    }
}
