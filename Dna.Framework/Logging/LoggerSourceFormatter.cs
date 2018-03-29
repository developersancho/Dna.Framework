using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dna
{
    public static class LoggerSourceFormatter
    {
        /// <summary>
        /// Formats the message including the source information pulled out of the state
        /// </summary>
        /// <param name="state">The state information about the log</param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string Format(object[] state, Exception exception)
        {
            var origin = (string)state[0];
            var filePath = (string)state[1];
            var lineNumber = (int)state[2];
            var message = (string)state[3];

            var exceptionMessage = exception?.ToString();
            if (exceptionMessage != null)
            {
                message += Environment.NewLine + exception;
            }

            return $"{message} [{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}]";
        }
    }
}
