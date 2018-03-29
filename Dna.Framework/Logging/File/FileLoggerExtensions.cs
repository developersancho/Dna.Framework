using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dna
{
    /// <summary>
    /// Extensions method for <see cref="FileLogger"/>
    /// </summary>
    public static class FileLoggerExtensions
    {
        /// <summary>
        /// add a new file logger to the specific path
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string path,
            FileLoggerConfiguration configuration = null)
        {
            if (configuration == null)
            {
                configuration = new FileLoggerConfiguration();
            }
            builder.AddProvider(new FileLoggerProvider(path, configuration));
            return builder;
        }

        /// <summary>
        /// Injects a file logger into the framework construction
        /// </summary>
        /// <param name="construction">The construction</param>
        /// <param name="logPath">The path of the file to log to</param>
        /// <returns></returns>
        public static FrameworkConstruction UseFileLogger(this FrameworkConstruction construction, string logPath = "log.txt")
        {
            // Make use of AddLogging extension
            construction.Services.AddLogging(options =>
            {
                // Add file logger
                options.AddFile(logPath);
            });

            // Chain the construction
            return construction;
        }
    }
}
