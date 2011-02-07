using System;
using System.Linq;
using Mono.Cecil;

namespace SmoothReflections
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = AssemblyDefinition.ReadAssembly(@"C:\Windows\Microsoft.net\Framework\v2.0.50727\mscorlib.dll");
            var systemObject = assembly.Modules[0].Types.First(x => x.Name == "Object");
            var ast = MSILtoCSharpConverter.ToAST(systemObject, "GetFieldInfo");
            var code = MSILtoCSharpConverter.ToCsharp(ast);
            Console.WriteLine(code);
            Console.ReadLine();
        }
    }
}
