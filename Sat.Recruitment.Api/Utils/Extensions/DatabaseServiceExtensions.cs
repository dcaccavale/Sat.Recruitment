using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.DataAccess;
using System;

namespace Sat.Recruitment.Api.Utils.Extensions
{
    public static class DatabaseServiceExtensions
    {
        /// <summary>
        /// Use to add Database services to inyect in service collection 
        /// </summary>
        /// <param name="services"></param>
        public static void AddDatabaseService(this IServiceCollection services)
        {
            //services
            //       .AddDbContext<SatRecruitmentContext>(options =>
            //        {

            //            options.UseSqlServer(
            //                "Data Source=localhost;Initial Catalog=SatRecruitment;User Id=sa; Password=smart1",
            //                dbOptions => dbOptions.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
            //                                      .MigrationsAssembly("Sat.Recruitment.DataAccess")
            //                                      .EnableRetryOnFailure(
            //                    maxRetryCount: 10,
            //                    maxRetryDelay: TimeSpan.FromSeconds(30),
            //                    errorNumbersToAdd: null)
            //          );
            //        });
            services
                  .AddDbContext<SatRecruitmentContext>(options =>
                  {

                      options.UseInMemoryDatabase("SatRecruitment");
                  });
        }
    }
}
