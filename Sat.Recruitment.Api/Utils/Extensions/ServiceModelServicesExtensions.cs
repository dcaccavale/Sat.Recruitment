using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Service;

namespace Sat.Recruitment.Api.Utils.Extensions
{
    public static class ServiceModelServicesExtensions
    {
        public static void AddServiceModelServicesExtensions(this IServiceCollection services) 
        {
            services.AddTransient(typeof(IUserServiceModel), typeof(UserServiceModel));
           
        }
    }
}
