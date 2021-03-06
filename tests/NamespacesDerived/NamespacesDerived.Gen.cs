using System.IO;
using CppSharp.Generators;
using CppSharp.Utils;

namespace CppSharp.Tests
{
    public class NamespacesDerivedTests : GeneratorTest
    {
        public NamespacesDerivedTests(GeneratorKind kind)
            : base("NamespacesDerived", kind)
        {
        }

        public override void Setup(Driver driver)
        {
            base.Setup(driver);
            driver.Options.GenerateDefaultValuesForArguments = true;
            driver.Options.GenerateClassTemplates = true;
            driver.Options.CompileCode = true;
            driver.Options.Modules[1].IncludeDirs.Add(GetTestsDirectory("NamespacesDerived"));
            const string @base = "NamespacesBase";
            var module = driver.Options.AddModule(@base);
            module.IncludeDirs.Add(Path.GetFullPath(GetTestsDirectory(@base)));
            module.Headers.Add($"{@base}.h");
            module.OutputNamespace = @base;
            module.LibraryDirs.Add(driver.Options.OutputDir);
            module.Libraries.Add($"{@base}.Native");
            driver.Options.Modules[1].Dependencies.Add(module);
        }
    }

    public static class NamespacesDerived
    {
        public static void Main()
        {
            ConsoleDriver.Run(new NamespacesDerivedTests(GeneratorKind.CSharp));
        }
    }
}

