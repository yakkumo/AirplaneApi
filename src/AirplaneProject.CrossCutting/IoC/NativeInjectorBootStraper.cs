﻿using AirplaneProject.Application.Interfaces;
using AirplaneProject.Application.Services;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Validations;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Core.Usecases;
using AirplaneProject.Core.Usecases.AirplaneUsecase;
using AirplaneProject.CrossCutting.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirplaneProject.CrossCutting.IoC
{
    public static class NativeInjectorBootStraper
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration config, bool isTest)
        {
            // AspNetUser
            services.AddScoped<IUser, AspNetUser>();
            
            // Application - Services
            services.AddScoped<IAirplaneAppService, AirplaneAppService>();

            // Core - Usecases
            services.AddScoped<EditarAirplaneUsecase>();
            services.AddScoped<IncluirAirplaneUsecase>();
            services.AddScoped<ExcluirAirplaneUsecase>();
            services.AddScoped<BookUsecase>();

            // Core - Validations
            services.AddScoped<IAirplaneValidation, AirplaneValidation>();

            // Infra - Data
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        public static void UpdateDatabase(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetService<AirplaneProjectContext>();
            context.Database.Migrate();
        }
    }
}
