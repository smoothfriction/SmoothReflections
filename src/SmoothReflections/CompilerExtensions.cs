using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using Microsoft.CSharp;

namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}


namespace SmoothReflections
{
    public static class MyExtension
    {
        public static string ToText(this CodeExpression expression)
        {
            var sb = new StringBuilder();
            using (var tw = new StringWriter(sb))
            {
                var cs = (CSharpCodeProvider)CodeDomProvider.CreateProvider("csharp");
                cs.GenerateCodeFromExpression(expression, tw, new CodeGeneratorOptions());
            }
            return sb.ToString();
        }
        public static string ToText(this CodeStatement statement)
        {
            var sb = new StringBuilder();
            using (var tw = new StringWriter(sb))
            {
                var cs = (CSharpCodeProvider)CodeDomProvider.CreateProvider("csharp");
                cs.GenerateCodeFromStatement(statement, tw, new CodeGeneratorOptions());
            }
            return sb.ToString();
        }
    }
}