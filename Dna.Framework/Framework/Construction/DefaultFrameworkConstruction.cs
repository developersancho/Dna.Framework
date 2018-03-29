using System;
using System.Collections.Generic;
using System.Text;

namespace Dna
{
    public class DefaultFrameworkConstruction : FrameworkConstruction
    {
        public DefaultFrameworkConstruction()
        {
            this.Configure()
                .UseDefaultService();
        }
    }
}
