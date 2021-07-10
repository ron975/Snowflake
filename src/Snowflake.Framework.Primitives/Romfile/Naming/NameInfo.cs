using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Snowflake.Romfile.Naming
{
    /// <summary>
    /// The information from a parsed file name.
    /// </summary>
    public sealed record NameInfo
    {

        /// <summary>
        /// The title of the game as it was parsed from the filename.
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// The title normalized according to the <a href="https://github.com/SnowflakePowered/shiratsu/blob/master/SPECIFICATION.md">shiratsu specification</a>.
        /// </summary>
        public string NormalizedTitle { get;  }
        /// <summary>
        /// An array of regions this game is associated with.
        /// </summary>
        public ImmutableArray<Region> Region { get; }
        /// <summary>
        /// Flags this game is associated with.
        /// </summary>
        public InfoFlags Flags { get; }
        /// <summary>
        /// The naming convention used to parse this name.
        /// </summary>
        public NamingConvention NamingConvention { get; }
        /// <summary>
        /// The version of the game if any.
        /// </summary>
        public RomVersion? Version { get; }
        /// <summary>
        /// The year of the game if any.
        /// </summary>
        public Year? Year { get; }

        /// <summary>
        /// Initialize a new NameInfo
        /// </summary>
        /// <param name="convention">The naming convention.</param>
        /// <param name="entryTitle">The title as it was parsed from the filename.</param>
        /// <param name="region">The regions as were parsed from the filename.</param>
        /// <param name="flags">The info flags as were parsed from the filename.</param>
        /// <param name="version">The version if available from the filename.</param>
        /// <param name="year">The year if available from the filename.</param>
        public NameInfo(NamingConvention convention, string entryTitle, ImmutableArray<Region> region, InfoFlags flags, RomVersion? version = null, Year? year = null)
            => (NamingConvention, Title, Region, Flags, Version, Year, NormalizedTitle) = (convention, entryTitle, region, flags, version, year, NameInfo.NormalizeTitle(entryTitle));

        private readonly static (int comma, string repl, Regex regex)[] ARTICLES =
        {
            (", Eine".Length,"Eine ", new Regex(@", Eine($|\s)", RegexOptions.Compiled)),
            (", The".Length, "The ", new Regex(@", The($|\s)", RegexOptions.Compiled)),
            (", Der".Length, "Der ", new Regex(@", Der($|\s)", RegexOptions.Compiled)),
            (", Die".Length, "Die ", new Regex(@", Die($|\s)", RegexOptions.Compiled)),
            (", Das".Length, "Das ", new Regex(@", Das($|\s)", RegexOptions.Compiled)),
            (", Ein".Length, "Ein ", new Regex(@", Ein($|\s)", RegexOptions.Compiled)),
            (", Les".Length, "Les ", new Regex(@", Les($|\s)", RegexOptions.Compiled)),
            (", Los".Length, "Los ", new Regex(@", Los($|\s)", RegexOptions.Compiled)),
            (", Las".Length, "Las ", new Regex(@", Las($|\s)", RegexOptions.Compiled)),
            (", An".Length, "An ", new Regex(@", An($|\s)", RegexOptions.Compiled)),
            (", De".Length, "De ", new Regex(@", De($|\s)", RegexOptions.Compiled)),
            (", La".Length, "La ", new Regex(@", La($|\s)", RegexOptions.Compiled)),
            (", Le".Length, "Le ", new Regex(@", Le($|\s)", RegexOptions.Compiled)),
            (", El".Length, "El ", new Regex(@", El($|\s)", RegexOptions.Compiled)),
            (", A".Length, "A ", new Regex(@", A($|\s)", RegexOptions.Compiled))
        };

        /// <summary>
        /// Normalize a title according to the <a href="https://github.com/SnowflakePowered/shiratsu/blob/master/SPECIFICATION.md">shiratsu specification</a>.
        /// </summary>
        /// <param name="title">The title to normalize.</param>
        /// <returns>The normalized title.</returns>
        private static string NormalizeTitle(string title)
        {
            var indices = ARTICLES.Select(a => (a, match: a.regex.Match(title))).Where(a => a.match.Success);
            if (!indices.Any())
                return title;
            var builder = new StringBuilder(title);
            (var art, var match) = indices.First();
            builder.Remove(match.Index, art.comma);
            builder.Insert(0, art.repl);
            return builder.ToString();
        }
    }
}
