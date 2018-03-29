using System;
using System.Collections.Generic;
using System.Text;

namespace Dna.Framework.ExceptionHandling.Interface
{
    public interface IExceptionHandler
    {

        void HandleError(Exception exception);

    }
}
