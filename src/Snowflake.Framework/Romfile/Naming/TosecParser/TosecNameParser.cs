using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;
using static Pidgin.Parser<char, string>;

namespace Snowflake.Romfile.Naming.TosecParser
{
    class TosecNameParser
        : IFilenameParser
    {
        Parser<char, char> parser = Char('a');

        public bool TryParse(string filename, out NameInfo? nameInfo)
        {
            
            throw new NotImplementedException();
        }
    }
}
