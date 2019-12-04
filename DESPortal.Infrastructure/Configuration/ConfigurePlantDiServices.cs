using DESPortal.Core.Services;
using DESPortal.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DESPortal.Infrastructure.Configuration
{
    public static class ConfigureNodeDiServices
    {
        public static IServiceCollection AddPlantDiService(this IServiceCollection services)
        {
            //services.AddScoped<IPlantService, PlantServiceMock>();
            services.AddScoped<IPlantService, PlantService>();
            return services;
        }
    }
}
