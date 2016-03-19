using Cake.Core;

namespace Cake.Common.Build.TravisCI.Data
{
    /// <summary>
    /// Provides TravisCI environment information for the current build.
    /// </summary>
    public class TravisCIEnvironmentInfo : TravisCIInfo
    {
        private readonly TravisCIBuildInfo _buildProvider;
        private readonly TravisCIJobInfo _jobProvider;
        private readonly TravisCIRepositoryInfo _repositoryProvider;

        /// <summary>
        /// Gets TravisCI build information.
        /// </summary>
        /// <value>
        /// The build.
        /// </value>
        public TravisCIBuildInfo Build
        {
            get { return _buildProvider; }
        }

        /// <summary>
        /// Gets TravisCI job information.
        /// </summary>
        /// <value>
        /// The job.
        /// </value>
        public TravisCIJobInfo Job
        {
            get { return _jobProvider; }
        }

        /// <summary>
        /// Gets TravisCI repository information.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public TravisCIRepositoryInfo Repository
        {
            get { return _repositoryProvider; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TravisCIEnvironmentInfo" /> is ci.
        /// </summary>
        /// <value>
        /// <c>true</c> if ci; otherwise, <c>false</c>.
        /// </value>
        public bool CI
        {
            get { return GetEnvironmentBoolean("CI"); }
        }

        /// <summary>
        /// Gets the TravisCI home directory.
        /// </summary>
        /// <value>
        /// The home.
        /// </value>
        public string Home
        {
            get { return GetEnvironmentString("HOME"); }
        }

        /// <summary>
        /// Gets a value indicating whether the environment is travis.
        /// </summary>
        /// <value>
        ///   <c>true</c> if travis; otherwise, <c>false</c>.
        /// </value>
        public bool Travis
        {
            get { return GetEnvironmentBoolean("TRAVIS"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TravisCIEnvironmentInfo"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        public TravisCIEnvironmentInfo(ICakeEnvironment environment) : base(environment)
        {
            _buildProvider = new TravisCIBuildInfo(environment);
            _jobProvider = new TravisCIJobInfo(environment);
            _repositoryProvider = new TravisCIRepositoryInfo(environment);
        }
    }
}
