// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Cake.Common.Tests.Fixtures.Tools.WiX;
using Cake.Common.Tools.WiX.Insignia;
using Cake.Core;
using Cake.Testing;
using Xunit;

namespace Cake.Common.Tests.Unit.Tools.WiX
{
    public sealed class InsigniaRunnerTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new InsigniaFixture();
                fixture.Environment = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsArgumentNullException(result, "environment");
            }
        }
        public sealed class TheRunMethod
        {
            [Fact]
            public void Should_Find_Insignia_Runner_If_Tool_Path_Not_Provided()
            {
                // Given
                var fixture = new InsigniaFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working/tools/insignia.exe", result.Path.FullPath);
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new InsigniaFixture();
                fixture.GivenProcessCannotStart();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Insignia: Process was not started.", result?.Message);
            }

            [Fact]
            public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
            {
                // Given
                var fixture = new InsigniaFixture();
                fixture.GivenProcessExitsWithCode(1);

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Insignia: Process returned an error (exit code 1).", result?.Message);
            }

            [Fact]
            public void Should_Throw_If_File_Path_Empty()
            {
                // Given
                var fixture = new InsigniaFixture();
                fixture.FilePath = string.Empty;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsArgumentNullException(result, "filepath");
            }

            [Fact]
            public void Should_Throw_If_File_Type_Null()
            {
                // Given
                var fixture = new InsigniaFixture();
                fixture.FilePath = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsArgumentNullException(result, "fileType");
            }

            [Theory]
            [InlineData(WiXInsigniaFileType.Database, "")]
            [InlineData(WiXInsigniaFileType.Bundle, "")]
            public void Should_Add_File_Type_If_Provided(WiXInsigniaFileType fileType, string expected)
            {
                // Given
                var fixture = new InsigniaFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }

            [Fact]
            public void Should_Add_If_Suppress_All_Warnings_Provided()
            {
                // Given
                var fixture = new InsigniaFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("-out \"\" -swall", result.Args);
            }

            [Fact]
            public void Should_Add_If_Suppress_Specific_Warnings_Provided()
            {
                // Given
                var fixture = new InsigniaFixture();
                fixture.Settings.SuppressSpecificWarnings = new[] { "0001", "0002" };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("-out \"\" -sw0001 -sw0002", result.Args);
            }

            [Fact]
            public void Should_Add_If_Treat_Specific_Warnings_As_Errors_Provided()
            {
                // Given
                var fixture = new InsigniaFixture();
                fixture.Settings.TreatSpecificWarningsAsErrors = new[] { "0001", "0002" };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("-out \"\" ", result.Args);
            }

            [Fact]
            public void Should_Add_If_Treat_All_Warnings_As_Errors_Provided()
            {
                // Given
                var fixture = new InsigniaFixture();
                fixture.Settings.TreatAllWarningsAsErrors = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("-out \"/Working/output.exe\" ", result.Args);
            }

            [Fact]
            public void Should_Add_If_Verbose_Provided()
            {
                // Given
                var fixture = new InsigniaFixture();

                fixture.Settings.Verbose = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("-out \"\" -v", result.Args);
            }
        }
    }
}
