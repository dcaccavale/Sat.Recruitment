using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Service;

namespace Sat.Recruitment.Api.Utils.Extensions
{
    public static class ServiceModelServicesExtensions
    {
        /// <summary>
        /// Use to add service Model managers to inyect in service collection 
        /// </summary>
        /// <param name="services"></param>
        public static void AddServiceModelServicesExtensions(this IServiceCollection services) 
        {
            services.AddTransient(typeof(IUserServiceModel), typeof(UserServiceModel));
           
        }
    }
}
