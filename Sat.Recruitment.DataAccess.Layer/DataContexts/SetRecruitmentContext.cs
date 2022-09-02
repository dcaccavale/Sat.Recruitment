
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Model;

namespace Sat.Recruitment.DataAccess
{
    public class SatRecruitmentContext : DbContext
    {
        public SatRecruitmentContext() { }

        public SatRecruitmentContext(DbContextOptions<SatRecruitmentContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
      


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           

            //optionsBuilder.UseInMemoryDatabase("Test_DB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    


        }
    }

}