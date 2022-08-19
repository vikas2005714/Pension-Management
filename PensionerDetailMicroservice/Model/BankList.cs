using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailMicroservice.Model
{
    public class BankList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BankName { get; set; }
    }
}
