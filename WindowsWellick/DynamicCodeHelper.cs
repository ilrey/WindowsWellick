using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;

namespace WindowsWellick
{
    internal class DynamicCodeHelper
    {
        public static void CompileCode(string codeToCompile)
        {
            var compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
            var references = new[]
            {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location),
            MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location)
            };
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(codeToCompile);
            var compilation = CSharpCompilation.Create("LibraryAssembly")
                .WithOptions(compilationOptions)
                .AddReferences(references)
                .AddSyntaxTrees(syntaxTree);

            using var codeToExecute = new MemoryStream();
            var emitResult = compilation.Emit(codeToExecute);

            if (emitResult.Success) { ExecuteCode(codeToExecute); }
        }

        public static void ExecuteCode(MemoryStream codeToExecute)
        {
            codeToExecute.Seek(0, SeekOrigin.Begin);
            var assembly = Assembly.Load(codeToExecute.ToArray());
            var libraryClassType = assembly.GetType("ProcessHelper");
            var libraryInstance = Activator.CreateInstance(libraryClassType);
            var libraryMethod = libraryClassType.GetMethod("Execute");
            libraryMethod?.Invoke(libraryInstance, null);
        }
    }
}