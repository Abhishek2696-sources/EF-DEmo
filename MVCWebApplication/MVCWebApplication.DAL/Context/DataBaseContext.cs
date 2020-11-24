using Microsoft.EntityFrameworkCore;
using MVCWebApplication.Dto;

namespace MVCWebApplication.DAL.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {

        }
       
        public virtual DbSet<EmployeeDto> Employee { get; set; }
    }
}
