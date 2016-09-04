// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Cake.Common.Tools.WiX.Insignia;
using Cake.Core.IO;
using Cake.Testing.Fixtures;

namespace Cake.Common.Tests.Fixtures.Tools.WiX
{
    public class InsigniaFixture : ToolFixture<InsigniaSettings>
    {
        public FilePath FilePath { get; set; }

        public WiXInsigniaFileType FileType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolFixture{TToolSettings}"/> class.
        /// </summary>
        public InsigniaFixture() : base("insignia.exe")
        {
            FilePath = new FilePath("./artifacts/cake.exe");
            Settings = new InsigniaSettings();
            Settings.OutputFile = new FilePath("./output.exe");
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        protected override void RunTool()
        {
            var runner = new InsigniaRunner(FileSystem, Environment, ProcessRunner, Tools);
            runner.Run(FilePath, FileType, Settings);
        }
    }
}
