using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Model.Request;
using Sat.Recruitment.Model.Request.Validations;
using System;

namespace Sat.Recruitment.Api.Utils.Extensions
{
    public  static class AppExtensionsServices
    {
        /// <summary>
        /// Use to add services to inyect in service collection 
        /// </summary>
        /// <param name="services"></param>
        public static void AddAppExtensionsServices(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.Conventions.Controller<Controllers.UsersController> ().HasApiVersion(new ApiVersion(1, 0));
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddLogging();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sat.Recruitment", Version = "v1" });
            });

        }
    }
}
