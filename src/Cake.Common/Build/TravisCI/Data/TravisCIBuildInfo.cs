using Cake.Core;

namespace Cake.Common.Build.TravisCI.Data
{
    /// <summary>
    /// Provides Travis CI build information for the current build.
    /// </summary>
    public class TravisCIBuildInfo : TravisCIInfo
    {
        /// <summary>
        /// Gets the branch for the current build.
        /// </summary>
        /// <value>
        /// The branch.
        /// </value>
        public string Branch
        {
            get { return GetEnvironmentString("TRAVIS_BRANCH"); }
        }

        /// <summary>
        /// Gets the build directory.
        /// </summary>
        /// <value>
        /// The build directory.
        /// </value>
        public string BuildDirectory
        {
            get { return GetEnvironmentString("TRAVIS_BUILD_DIR"); }
        }

        /// <summary>
        /// Gets the build identifier.
        /// </summary>
        /// <value>
        /// The build identifier.
        /// </value>
        public string BuildId
        {
            get { return GetEnvironmentString("TRAVIS_BUILD_ID"); }
        }

        /// <summary>
        /// Gets the build number.
        /// </summary>
        /// <value>
        /// The build number.
        /// </value>
        public int BuildNumber
        {
            get { return GetEnvironmentInteger("TRAVIS_BUILD_NUMBER"); }
        }
        
        /// <summary>
        /// Gets a value indicating whether [travis secure environment variables].
        /// </summary>
        /// <value>
        /// <c>true</c> if [travis secure environment variables]; otherwise, <c>false</c>.
        /// </value>
        public bool SecureEnvironmentVariables
        {
            get { return GetEnvironmentBoolean("TRAVIS_SECURE_ENV_VARS"); }
        }

        /// <summary>
        /// Gets a value indicating whether the build is successful.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [test result]; otherwise, <c>false</c>.
        /// </value>
        public bool TestResult
        {
            get { return GetEnvironmentBoolean("TRAVIS_TEST_RESULT"); }
        }

        /// <summary>
        /// Gets the tag name for the current build.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag
        {
            get { return GetEnvironmentString("TRAVIS_TAG"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TravisCIBuildInfo"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        public TravisCIBuildInfo(ICakeEnvironment environment) : base(environment)
        {
        }
    }
}
