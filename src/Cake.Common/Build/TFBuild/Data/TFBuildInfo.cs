// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Cake.Core;

namespace Cake.Common.Build.TFBuild.Data
{
    /// <summary>
    /// Provides TF Build info for the current build.
    /// </summary>
    public sealed class TFBuildInfo : TFInfo
    {
        // TODO: https://www.visualstudio.com/en-us/docs/build/define/variables

        /// <summary>
        /// Initializes a new instance of the <see cref="TFBuildInfo"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        public TFBuildInfo(ICakeEnvironment environment)
            : base(environment)
        {
        }

        /// <summary>
        /// Gets the ID of the record for the completed build.
        /// </summary>
        /// <value>
        /// The ID of the record for the completed build.
        /// </value>
        public int Id => GetEnvironmentInteger("BUILD_BUILDID");

        /// <summary>
        /// Gets the name of the completed build.
        /// </summary>
        /// <remarks>You can specify the build number format that generates this value in the build definition.</remarks>
        /// <value>
        /// The name of the completed build.
        /// </value>
        public string Number => GetEnvironmentString("BUILD_BUILDNUMBER");

        /// <summary>
        /// Gets the URI for the build.
        /// </summary>
        /// <example><c>vstfs:///Build/Build/1430</c></example>
        /// <value>
        /// The URI for the build.
        /// </value>
        public Uri Uri => new Uri(GetEnvironmentString("BUILD_BUILDURI"));

        /// <summary>
        /// Gets the user who queued the build.
        /// </summary>
        /// <value>
        /// The user who queued the build.
        /// </value>
        public string QueuedBy => GetEnvironmentString("BUILD_QUEUEDBY");

        /// <summary>
        /// Gets the user the build was requested for.
        /// </summary>
        /// <value>
        /// The user the build was requested for.
        /// </value>
        public string RequestedFor => GetEnvironmentString("BUILD_REQUESTEDFOR");

        /// <summary>
        /// Gets the email of the user the build was requested for.
        /// </summary>
        /// <value>
        /// The email of the user the build was requested for.
        /// </value>
        public string RequestedForEmail => GetEnvironmentString("BUILD_REQUESTEDFOREMAIL");

        /// <summary>
        /// Gets the local path on the agent where any artifacts are copied to before being pushed to their destination. 
        /// </summary>
        /// <example><c>c:\agent\_work\1\a</c></example>
        /// <value>
        /// The artifact staging directory.
        /// </value>
        public string ArtifactStagingDirectory => GetEnvironmentString("BUILD_ARTIFACTSTAGINGDIRECTORY");

        /// <summary>
        /// Gets local path on the agent you can use as an output folder for compiled binaries.
        /// </summary>
        /// <value>
        /// The binaries directory.
        /// </value>
        public string BinariesDirectory => GetEnvironmentString("BUILD_BINARIESDIRECTORY");

        /// <summary>
        /// Gets the name of the build definition..
        /// </summary>
        /// <value>
        /// The definition.
        /// </value>
        public string Definition => GetEnvironmentString("BUILD_DEFINITIONNAME");

        /// <summary>
        /// Gets the version of the build definition.
        /// </summary>
        /// <value>
        /// The definition version.
        /// </value>
        public string DefinitionVersion => GetEnvironmentString("BUILD_DEFINITIONVERSION");
    }
}
