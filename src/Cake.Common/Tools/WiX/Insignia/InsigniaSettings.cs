// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Common.Tools.WiX.Insignia
{
    /// <summary>
    /// Contains settings used by <see cref="InsigniaRunner"/>.
    /// </summary>
    public class InsigniaSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether to reattach the engine to a bundle.
        /// </summary>
        /// <value>
        ///   <c>true</c> if reattach; otherwise, <c>false</c>.
        /// </value>
        public bool Reattach { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to skip printing the logo.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [no logo]; otherwise, <c>false</c>.
        /// </value>
        public bool NoLogo { get; set; }

        /// <summary>
        /// Gets or sets the output file.
        /// Defaults to databaseFile or bundleFile.
        /// If out is a directory name ending in '\', output to a file with
        /// the same name as the databaseFile or bundleFile in that directory
        /// </summary>
        /// <value>
        /// The output file.
        /// </value>
        public Path OutputFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to suppress all warnings.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [suppress all warnings]; otherwise, <c>false</c>.
        /// </value>
        public bool SuppressAllWarnings { get; set; }

        /// <summary>
        /// Gets or sets the list of specific warnings or messages to suppress.
        /// </summary>
        /// <value>
        /// The suppress specific warnings.
        /// </value>
        public IEnumerable<string> SuppressSpecificWarnings { get; set; }

        /// <summary>
        /// Gets or sets the treat specific warnings as errors.
        /// </summary>
        /// <value>
        /// The treat specific warnings as errors.
        /// </value>
        public IEnumerable<string> TreatSpecificWarningsAsErrors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to treat all warnings as errors.
        /// </summary>
        /// <value>
        /// <c>true</c> if [treat all warnings as errors]; otherwise, <c>false</c>.
        /// </value>
        public bool TreatAllWarningsAsErrors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether output is verbose.
        /// </summary>
        /// <value>
        ///   <c>true</c> if verbose; otherwise, <c>false</c>.
        /// </value>
        public bool Verbose { get; set; }
    }
}