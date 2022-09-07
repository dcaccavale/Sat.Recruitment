using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.DataAccess.Repositories;

namespace Sat.Recruitment.Api.Utils.Extensions
{
    public static class RepositoriesServicesExtensions
    {
        /// <summary>
        /// Use to add Repositories services to inyect in service collection 
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositoriesServicesExtensions(this IServiceCollection services) 
        {
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));

        }
    }
}
