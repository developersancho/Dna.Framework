using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Dna
{
    /// <summary>
    /// Extension for <see cref="ILogger"/>
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Logs a critical message, including the source of the log
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="origin"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <param name="args"></param>
        public static void LogCriticalSource(
            this ILogger logger,
            string message,
            EventId eventId = new EventId(),
            Exception exception = null,
            [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            params object[] args) =>
            logger.Log(LogLevel.Critical, eventId, args.Prepend(origin, filePath, lineNumber, message), exception, LoggerSourceFormatter.Format);

    }
}
