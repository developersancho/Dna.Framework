using System;
using System.Collections.Generic;
using System.Text;

namespace Dna.Framework.Environment
{
    /// <summary>
    /// Details about the current system environment
    /// </summary>
    public class FrameworkEnvironment
    {
        #region Public Properties

        /// <summary>
        /// True If we are development
        /// </summary>
        public bool IsDevelopment { get; set; } = true;

        public string Configuration => IsDevelopment ? "Development" : "Production";

        #endregion

        #region Constructor

        public FrameworkEnvironment()
        {
#if RELEASE
            IsDevelopment = false;    
#endif
        }

        #endregion

    }
}
