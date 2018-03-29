using Dna.Framework.Environment;
using Dna.Framework.ExceptionHandling.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Dna.Framework
{

    public static class Framework
    {
        #region Private Members
        private static IServiceProvider ServiceProvider;

        #endregion

        #region Public Properties
        /// <summary>
        /// The Dependency Injection service provider
        /// </summary>
        public static IServiceProvider Provider => ServiceProvider;
        /// <summary>
        /// Gets to default logger the framework
        /// </summary>
        public static ILogger Logger => Provider.GetService<ILogger>();
        /// <summary>
        /// Gets the configuration for the framework environment
        /// </summary>
        public static IConfiguration Configuration => Provider.GetService<IConfiguration>();
        /// <summary>
        /// Gets to framework environment of this class
        /// </summary>
        public static FrameworkEnvironment Environment => Provider.GetService<FrameworkEnvironment>();

        public static IExceptionHandler ExceptionHandler => Provider.GetService<IExceptionHandler>();
        #endregion

        #region method Methods

        /// <summary>
        /// should be called at the very start of your application to configure and setup for Dna.Framework
        /// </summary>
        /// <param name="configure">To Action to add custom configurations to the configuration builder</param>
        /// <param name="injection">To Action to inject services into to service collection</param>
        public static void Build(this FrameworkConstruction construction)
        {

            // Build the service provider
            ServiceProvider = construction.Services.BuildServiceProvider();

            // appsettings dosyasında ki alanlara erişme
            var a = Configuration.GetSection("Logging").GetChildren();

            // log the startup complete
            Logger.LogCriticalSource($"Dna Framework started in {construction.Environment.Configuration}...");
        }

        #endregion

    }
}
