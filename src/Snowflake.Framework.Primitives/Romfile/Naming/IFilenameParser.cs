using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowflake.Romfile.Naming
{
    /// <summary>
    /// A parser for structured filename
    /// </summary>
    public interface IFilenameParser
    {
        /// <summary>
        /// Tries to parse a name info.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="nameInfo"></param>
        /// <returns></returns>
        public bool TryParse(string filename, out NameInfo? nameInfo);
    }
}
