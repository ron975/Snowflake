using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowflake.Romfile.Naming
{
    /// <summary>
    /// Represents a four digit year
    /// </summary>
    public sealed record Year
    {
        /// <summary>
        /// The most significant digit in a four-digit year (2 for the year 2021)
        /// </summary>
        public int? Millenium { get; }
        /// <summary>
        /// Second most significant digit in a year (0 for the year 2021)
        /// </summary>
        public int? Century { get; }
        /// <summary>
        /// The third most siginificant digit in a year (2 for the year 2021)
        /// </summary>
        public int? Decade { get; }
        /// <summary>
        /// The least significant digit in a year.
        /// </summary>
        public int? Annus { get; }

        /// <summary>
        /// Create a fully specified four digit year.
        /// </summary>
        /// <param name="m">The year millenium</param>
        /// <param name="c">The year century</param>
        /// <param name="d">The year decade</param>
        /// <param name="a">The year annus</param>
        public Year(int m, int c, int d, int a) => (Millenium, Century, Decade, Annus) = (m, c, d, a);

        /// <summary>
        /// Create a four digit year with unknown exact year
        /// </summary>
        /// <param name="m">The year millenium</param>
        /// <param name="c">The year century</param>
        /// <param name="d">The year decade</param>
        public Year(int m, int c, int d) => (Millenium, Century, Decade, Annus) = (m, c, d, null);

        /// <summary>
        /// Create a four digit year with unknown decade
        /// </summary>
        /// <param name="m">The year millenium</param>
        /// <param name="c">The year century</param>
        public Year(int m, int c) => (Millenium, Century, Decade, Annus) = (m, c, null, null);

        /// <summary>
        /// Converts the year to a string.
        /// </summary>
        /// <returns>A strign representing the year.</returns>
        public override string ToString() => $"{OrX(Millenium)}{OrX(Century)}{OrX(Decade)}{OrX(Annus)}";

        private static string OrX(int? integer)
            => integer?.ToString() ??  "x";
    }
}
