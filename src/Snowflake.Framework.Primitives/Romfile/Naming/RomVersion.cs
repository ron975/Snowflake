using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowflake.Romfile.Naming
{
    /// <summary>
    /// Represents a version in a filename
    /// </summary>
    public sealed record RomVersion
    {
        /// <summary>
        /// The tag used to specify this version. 
        /// For example, 'Version' or 'Rev'.
        /// </summary>
        public string Tag { get; }

        /// <summary>
        /// The major version or revision number.
        /// </summary>
        public string Major { get; }

        /// <summary>
        /// The minor version or revision number
        /// </summary>
        public string? Minor { get; }

        /// <summary>
        /// The version prefix, if any.
        /// This is not the version type, but the prefix that appears, separated by a space, before the type.
        /// </summary>
        public string? Prefix { get; }

        /// <summary>
        /// The version suffix, if any.
        /// This appears after the version number, separated by a space.
        /// </summary>
        public string Suffix { get; }

        /// <summary>
        /// Intantiates a Version instance.
        /// </summary>
        /// <param name="tag">The tag used to specify this version. </param>
        /// <param name="major">The major version.</param>
        /// <param name="minor">The minor version</param>
        public RomVersion(string tag, string major, string minor) => (Tag, Major, Minor) = (tag, major, minor);

        /// <summary>
        /// Intantiates a Version instance without a minor version.
        /// </summary>
        /// <param name="tag">The tag used to specify this version. </param>
        /// <param name="major">The major version.</param>
        public RomVersion(string tag, string major) => (Tag, Major, Minor) = (tag, major, null);

    }
}
