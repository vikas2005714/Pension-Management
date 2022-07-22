using Microsoft.EntityFrameworkCore;
using PensionerDetailMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailMicroservice.Data
{
    public class ApplicationDbContex : DbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> option):base(option)
        {

        }

        
        public DbSet<PensionDetails> pensiondetail { get; set; }
    }
}
