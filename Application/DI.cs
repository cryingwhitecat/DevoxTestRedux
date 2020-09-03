using DevoxTestRedux.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DevoxTestRedux.Application
{
    public static class DI
    {
        /// <summary>
        /// Injecting necessary dependencies
        /// </summary>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
        /// <summary>
        /// Building and injecting Serilog logger
        /// </summary>
        /// <param name="filePath">Log file path</param>
        /// <param name="configuration">Serilog logger configuration</param>
        public static IServiceCollection AddSerilogServices(this IServiceCollection services,
            LoggerConfiguration configuration = null, string filePath="log.txt")
        {
            LoggerConfiguration cfg;
            #region Logger Cfg Init
            if (configuration == null)
            {
                cfg = new LoggerConfiguration().
                    MinimumLevel.Information().
                    WriteTo.Console().
                    WriteTo.File(filePath, rollingInterval: RollingInterval.Day);
            }
            else
            { 
                cfg = configuration; 
            }
            #endregion
            Log.Logger = cfg.CreateLogger();
            AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
            return services.AddSingleton(Log.Logger);
        }
    }
}
