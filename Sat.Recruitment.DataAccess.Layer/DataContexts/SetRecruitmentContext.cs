
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Model;

namespace DataAccess
{
    public class SetRecruitmentContext : DbContext
    {
        public SetRecruitmentContext() { }

        public SetRecruitmentContext(DbContextOptions<SetRecruitmentContext> options)
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