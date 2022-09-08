
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.ApiAuth.Model;

namespace Sat.Recruitment.ApiAuth.DataAccess
{
    public class ApiAuthContext : DbContext
    {
        public ApiAuthContext() { }

        public ApiAuthContext(DbContextOptions<ApiAuthContext> options)
            : base(options)
        {
        }
        public virtual DbSet<UserInfo> UserInfo { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            //optionsBuilder.UseInMemoryDatabase("Test_DB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           

        }
    }

}