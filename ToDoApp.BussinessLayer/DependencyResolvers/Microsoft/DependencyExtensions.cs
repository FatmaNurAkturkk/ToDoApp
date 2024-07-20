using AutoMapper;
using AutoMapper.Execution;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.BussinessLayer.Interfaces;
using ToDoApp.BussinessLayer.Mapping.AutoMapperMappings;
using ToDoApp.BussinessLayer.Services;
using ToDoApp.BussinessLayer.ValidationRules;
using ToDoApp.DataAccessLayer.Context;
using ToDoApp.DataAccessLayer.UnitOfWork;
using ToDoApp.Dtos.WorkDtos;

namespace ToDoApp.BussinessLayer.DependencyResolvers.Microsoft
{
    public static class DependencyExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ToDoContext>(opt =>
            {
                opt.UseSqlServer("server=LAPTOP-TAKVLFNA;database=ToDoAppDb;integrated security=true;");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkServices, WorkService>();

            //FluentDependency
            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();
        }
    }
}
