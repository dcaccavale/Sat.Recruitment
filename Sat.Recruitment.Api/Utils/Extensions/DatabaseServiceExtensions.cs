using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Utils.Extensions
{
    public static class DatabaseServiceExtensions
    {
        public static void AddDatabaseService(this IServiceCollection services)
        {
            services
                   .AddDbContext<SatRecruitmentContext>(options =>
                    {

                        options.UseSqlServer(
                            "Data Source=localhost;Initial Catalog=SatRecruitment;User Id=sa; Password=smart1",
                            dbOptions => dbOptions.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                                                  .MigrationsAssembly("Sat.Recruitment.DataAccess"));
                    });
        }
    }
}
