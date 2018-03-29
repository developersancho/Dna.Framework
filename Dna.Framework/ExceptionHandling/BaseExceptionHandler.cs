using System;
using System.Collections.Generic;
using System.Text;
using Dna.Framework.ExceptionHandling.Interface;

namespace Dna.Framework.ExceptionHandling
{
    public class BaseExceptionHandler : IExceptionHandler
    {
        public void HandleError(Exception exception)
        {
            Framework.Logger.LogCriticalSource("Undhandled exception occurred", exception: exception);
        }
    }
}
