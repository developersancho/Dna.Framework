using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace Dna
{
    /// <summary>
    /// A logger that writes to logs the file
    /// </summary>
    public class FileLogger : ILogger
    {
        protected string mCategoryName;
        protected string mFilePath;
        protected FileLoggerConfiguration mConfiguration;
        protected static ConcurrentDictionary<string, object> FileLocks = new ConcurrentDictionary<string, object>();

        public FileLogger(string categoryName, string filePath, FileLoggerConfiguration mConfiguration)
        {
            mFilePath = Path.GetFullPath(filePath);
            this.mCategoryName = categoryName;
            this.mFilePath = filePath;
            this.mConfiguration = mConfiguration;
        }

        /// <summary>
        /// Logs the message to file
        /// </summary>
        /// <typeparam name="TState">The type of the details of the message</typeparam>
        /// <param name="logLevel">The Log level</param>
        /// <param name="eventId">The Id</param>
        /// <param name="state">The details of the message</param>
        /// <param name="exception">Any exception of the log</param>
        /// <param name="formatter">The formatter for converting the state end exception to a message</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var timeLogString = mConfiguration.LogTime ? $"[{currentTime}]" : "";
            var message = formatter(state, exception);
            var output = $"{timeLogString}{message}{Environment.NewLine}";
            var normalizePath = mFilePath.ToUpper();
            var fileLock = FileLocks.GetOrAdd(normalizePath, path => new object());
            lock (fileLock)
            {
                File.AppendAllText(mFilePath, message);
            }

        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= mConfiguration.LogLevel;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
