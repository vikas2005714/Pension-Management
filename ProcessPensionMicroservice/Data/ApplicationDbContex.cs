using Microsoft.EntityFrameworkCore;
using ProcessPensionMicroservice.Model;


namespace ProcessPensionMicroservice.Data
{
    public class ApplicationDbContex : DbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> option):base(option)
        {
        } 
        public DbSet<ProcessPension> processPensions { get; set; }
    }
}
