using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowflake.Romfile.Naming
{
    public sealed class HeuristicRegexParser
        : IFilenameParser
    {
        public bool TryParse(string filename, out NameInfo? nameInfo)
        {
            var structured = new StructuredFilename(filename);
            if (structured.NamingConvention == NamingConvention.Unknown)
            {
                nameInfo = null;
                return false;
            }
            nameInfo = new NameInfo(structured.NamingConvention, structured.Title, ImmutableArray.Create<Region>(), InfoFlags.None);
            return true;
        }
    }
}
