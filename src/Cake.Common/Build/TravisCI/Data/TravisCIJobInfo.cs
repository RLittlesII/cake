using Cake.Core;

namespace Cake.Common.Build.TravisCI.Data
{
    /// <summary>
    /// Provides Travis CI job information for the current build.
    /// </summary>
    public class TravisCIJobInfo : TravisCIInfo
    {
        /// <summary>
        /// Gets the job identifier.
        /// </summary>
        /// <value>
        /// The job identifier.
        /// </value>
        public string JobId
        {
            get { return GetEnvironmentString("TRAVIS_JOB_ID"); }
        }

        /// <summary>
        /// Gets the job number.
        /// </summary>
        /// <value>
        /// The job number.
        /// </value>
        public string JobNumber
        {
            get { return GetEnvironmentString("TRAVIS_JOB_NUMBER"); }
        }

        /// <summary>
        /// Gets the name of the operating system.
        /// </summary>
        /// <value>
        /// The name of the os.
        /// </value>
        public string OSName
        {
            get { return GetEnvironmentString("TRAVIS_OS_NAME"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TravisCIJobInfo"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        public TravisCIJobInfo(ICakeEnvironment environment) : base(environment)
        {
        }
    }
}
