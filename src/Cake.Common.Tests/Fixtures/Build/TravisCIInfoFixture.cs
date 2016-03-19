using Cake.Common.Build.TravisCI.Data;
using Cake.Core;
using NSubstitute;

namespace Cake.Common.Tests.Fixtures.Build
{
    internal sealed class TravisCIInfoFixture
    {
        public ICakeEnvironment Environment { get; set; }

        public TravisCIInfoFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();

            // TravisCIEnvironmentInfo
            Environment.GetEnvironmentVariable("CI").Returns("true");
            Environment.GetEnvironmentVariable("TRAVIS").Returns("true");
            Environment.GetEnvironmentVariable("HOME").Returns("/home/travis");

            // TravisCIBuildInfo
            Environment.GetEnvironmentVariable("TRAVIS_BRANCH").Returns("master");
            Environment.GetEnvironmentVariable("TRAVIS_BUILD_DIR").Returns("/home/travis/build/");
            Environment.GetEnvironmentVariable("TRAVIS_BUILD_ID").Returns("");
            Environment.GetEnvironmentVariable("TRAVIS_BUILD_NUMBER").Returns("934");
            Environment.GetEnvironmentVariable("TRAVIS_TEST_RESULT").Returns("0");
            Environment.GetEnvironmentVariable("TRAVIS_TAG").Returns("v0.10.0");

            // TravisCIJobInfo
            Environment.GetEnvironmentVariable("TRAVIS_JOB_ID").Returns("");
            Environment.GetEnvironmentVariable("TRAVIS_JOB_NUMBER").Returns("934.2");
            Environment.GetEnvironmentVariable("TRAVIS_OS_NAME").Returns("osx");
            Environment.GetEnvironmentVariable("TRAVIS_SECURE_ENV_VARS").Returns("false");

            // TravisCIRepositoryInfo
            Environment.GetEnvironmentVariable("TRAVIS_COMMIT").Returns("");
            Environment.GetEnvironmentVariable("TRAVIS_COMMIT_RANGE").Returns("");
            Environment.GetEnvironmentVariable("TRAVIS_PULL_REQUEST").Returns("");
            Environment.GetEnvironmentVariable("TRAVIS_REPO_SLUG").Returns("");
        }

        public TravisCIBuildInfo CreateBuildInfo()
        {
            return new TravisCIBuildInfo(Environment);
        }

        public TravisCIJobInfo CreateJobInfo()
        {
            return new TravisCIJobInfo(Environment);
        }

        public TravisCIRepositoryInfo CreateRepositoryInfo()
        {
            return new TravisCIRepositoryInfo(Environment);
        }

        public TravisCIEnvironmentInfo CreateEnvironmentInfo()
        {
            return new TravisCIEnvironmentInfo(Environment);
        }
    }
}
