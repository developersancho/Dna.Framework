using System;
using System.Collections.Generic;
using System.Text;
using Dna.Framework.Environment;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dna
{
    /// <summary>
    /// The Construction information when starting up and configuring framework
    /// </summary>
    public class FrameworkConstruction
    {
        public IServiceCollection Services { get; set; }
        public FrameworkEnvironment Environment { get; set; }
        public IConfiguration Configuration { get; set; }

        public FrameworkConstruction()
        {
            #region Initialize
            // create a new list of dependencies
            Services = new ServiceCollection();
            #endregion

            #region Environment
            // create environment details
            Environment = new FrameworkEnvironment();
            // Inject environment into service
            Services.AddSingleton(Environment);
            #endregion
        }
    }
}
