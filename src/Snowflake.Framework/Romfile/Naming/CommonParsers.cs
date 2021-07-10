using Pidgin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pidgin.Parser;
using static Pidgin.Parser<char, string>;
using StringParser = Pidgin.Parser<char, string>;
namespace Snowflake.Romfile.Naming
{
    internal static class CommonParsers
    {
      
        public static StringParser OpenParens = String("(");
        public static StringParser CloseParens = String(")");
        public static Parser<char, T> InParens<T>(Parser<char, T> inner) =>
            inner.Between(OpenParens, CloseParens);

        public static StringParser OpenBracket = String("[");
        public static StringParser CloseBracket = String("]");

        public static StringParser InBrackets(StringParser inner) =>
            inner.Between(OpenBracket, CloseBracket);
    }
}
