using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    public abstract class Father
    {
        /// <summary>
        /// Looks for son.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>Double son.</returns>
        public double LookForSon(Son s)
        {
            return 0;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Son : Father { }
}
