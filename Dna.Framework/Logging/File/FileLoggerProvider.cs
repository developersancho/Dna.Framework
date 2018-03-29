using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Dna
{
    /// <summary>
    /// Provides to ability to log the file
    /// </summary>
    public class FileLoggerProvider : ILoggerProvider
    {
        #region Protected Members

        protected string mFilePath;

        /// <summary>
        /// The configuration to use when creating loggers
        /// </summary>
        protected readonly FileLoggerConfiguration mConfiguration;
        /// <summary>
        /// Keeps track of loggers already created
        /// </summary>
        protected readonly ConcurrentDictionary<string, FileLogger> mLoggers = new ConcurrentDictionary<string, FileLogger>();
        #endregion

        public FileLoggerProvider(string path, FileLoggerConfiguration configuration)
        {
            mConfiguration = configuration;
            mFilePath = path;
        }

        #region ILoggerProvider Implementation

        public void Dispose()
        {
            // clear the list of loggers
            mLoggers.Clear();
        }

        /// <summary>
        /// creates a file logger based on the categoryname
        /// </summary>
        /// <param name="categoryName">The Category name of this Logger</param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return mLoggers.GetOrAdd(categoryName, name => new FileLogger(name, mFilePath, mConfiguration));
        }

        #endregion

    }
}
