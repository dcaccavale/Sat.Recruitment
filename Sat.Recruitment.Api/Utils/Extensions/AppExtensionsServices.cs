using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Model.Request;
using Sat.Recruitment.Model.Request.Validations;
using System;

namespace Sat.Recruitment.Api.Utils.Extensions
{
    public  static class AppExtensionsServices
    {
        public static void AddAppExtensionsServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddLogging();

        }
    }
}
