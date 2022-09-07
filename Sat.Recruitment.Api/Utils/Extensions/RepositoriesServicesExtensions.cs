using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.DataAccess.Repositories;

namespace Sat.Recruitment.Api.Utils.Extensions
{
    public static class RepositoriesServicesExtensions
    {
        public static void AddRepositoriesServicesExtensions(this IServiceCollection services) 
        {
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));

        }
    }
}
