using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.ApiAuth.DataAccess;

namespace Sat.Recruitment.ApiAuth.Extensions
{
    public static class DatabaseServiceExtensions
    {
        /// <summary>
        /// Use to add Database services to inyect in service collection 
        /// </summary>
        /// <param name="services"></param>
        public static void AddDatabaseService(this IServiceCollection services)
        {

            services
                  .AddDbContext<ApiAuthContext>(options =>
                  {

                      options.UseInMemoryDatabase("SatRecruitmentAuth");
                  });
        }
    }
}
