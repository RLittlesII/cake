// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Common.Tools.WiX.Insignia
{
    /// <summary>
    /// The WiX Insignia runner.
    /// </summary>
    public sealed class InsigniaRunner : Tool<InsigniaSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="InsigniaRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public InsigniaRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            _environment = environment;
        }

        /// <summary>
        /// Runs the Wix Insignia runner for the specified file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="settings">The settings.</param>
        public void Run(FilePath filePath, WiXInsigniaFileType fileType, InsigniaSettings settings)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(filePath, fileType, settings));
        }

        private ProcessArgumentBuilder GetArguments(FilePath filePath, WiXInsigniaFileType fileType, InsigniaSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // set the input file type
            switch (fileType)
            {
                case WiXInsigniaFileType.Bundle:
                    builder.Append("-ib");
                    break;
                case WiXInsigniaFileType.Database:
                    builder.Append("-im");
                    break;
                case WiXInsigniaFileType.Reattach:
                    builder.Append("-ab");
                    break;
            }

            // append the file to process
            builder.AppendQuoted(filePath.MakeAbsolute(_environment).FullPath);

            // output file for WiX insignia
            builder.Append("-out");
            builder.AppendQuoted(settings.OutputFile.M);

            // Suppress all warnings
            if (settings.SuppressAllWarnings)
            {
                builder.Append("-swall");
            }

            // verbosity
            if (settings.Verbose)
            {
                builder.Append("-v");
            }

            // No logo
            if (settings.NoLogo)
            {
                builder.Append("-nologo");
            }

            // Suppress specific warnings
            if (settings.SuppressSpecificWarnings != null && settings.SuppressSpecificWarnings.Any())
            {
                var warnings = settings.SuppressSpecificWarnings.Select(warning => string.Format(CultureInfo.InvariantCulture, "-sw{0}", warning));
                foreach (var warning in warnings)
                {
                    builder.Append(warning);
                }
            }

            return builder;
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "Insignia";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "insignia.exe" };
        }
    }
}
