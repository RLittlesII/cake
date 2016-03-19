using Cake.Common.Build.TravisCI.Data;

namespace Cake.Common.Build.TravisCI
{
    /// <summary>
    /// Represents a TravisCI Provider.
    /// </summary>
    public interface ITravisCIProvider
    {
        /// <summary>
        /// Gets a value indicating whether this instance is running on travis ci.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is running on travis ci; otherwise, <c>false</c>.
        /// </value>
        bool IsRunningOnTravisCI { get; }

        /// <summary>
        /// Gets the environment.
        /// </summary>
        /// <value>
        /// The environment.
        /// </value>
        TravisCIEnvironmentInfo Environment { get; }

        /// <summary>
        /// Write the start of a message fold to the Travis CI build log.
        /// </summary>
        /// <param name="name">Name of the group.</param>
        void WriteStartFold(string name);

        /// <summary>
        /// Write the start of a message fold to the Travis CI build log.
        /// </summary>
        /// <param name="name">Name of the group.</param>
        void WriteEndFold(string name);
    }
}
