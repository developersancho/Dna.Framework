using System;
using System.IO;
using Dna.Framework.ExceptionHandling;
using Dna.Framework.ExceptionHandling.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dna
{
    /// <summary>
    /// Extensions method for Framework
    /// </summary>
    public static class FrameworkExtensions
    {
        /// <summary>
        /// Add a default logger so that we can get a non-generic ILogger
        /// that will have the category name of Dna.Framework
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddDefaultLogger(this FrameworkConstruction construction)
        {
            // add logging is default
            construction.Services.AddLogging(options =>
            {
                // setup loggers from configuration
                options.AddConfiguration(construction.Configuration.GetSection("Logging"));
                // add console logger
                options.AddConsole();
                // add debug logger
                options.AddDebug();
                // add file logger
                // options.AddFile("log.txt");

            });

            construction.Services.AddTransient(provider => provider.GetService<ILoggerFactory>().CreateLogger("Dna"));
            return construction;
        }


        public static FrameworkConstruction Configure(this FrameworkConstruction construction, Action<IConfigurationBuilder> configure = null)
        {

            var configurationBuilder = new ConfigurationBuilder()
                // add evironment variable
                .AddEnvironmentVariables()
                // set base path for Json files as the startup location of the app
                .SetBasePath(Directory.GetCurrentDirectory())
                // add application setting to json file
                // bu dosyayı bu frameworku kullanacağın projeye ekle appsettings.json diye birde
                // sağ tıkla properties ten Copy if newer yapmalısın
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{construction.Environment.Configuration}.json", optional: true, reloadOnChange: true);

            // set custom configuration happen
            configure?.Invoke(configurationBuilder);

            // inject configuration into services
            var configuration = configurationBuilder.Build();
            construction.Services.AddSingleton<IConfiguration>(configuration);

            construction.Configuration = configuration;

            return construction;
        }

        /// <summary>
        /// Inject all of the default services used by Dna.Framework for a quicker and cleaner setup
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction UseDefaultService(this FrameworkConstruction construction)
        {
            construction.AddDefaultExceptionHandler();
            construction.AddDefaultLogger();

            return construction;
        }


        /// <summary>
        /// Inject all of the default Exception used by Dna.Framework for a quicker and cleaner setup
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddDefaultExceptionHandler(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IExceptionHandler>(new BaseExceptionHandler());
            return construction;
        }
    }
}
