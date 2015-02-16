using System;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

// Write a program that calculates the value of given arithmetical expression. Examples:
//   (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) = 10.60...
//   pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) = 21.22...
class ExpressionCalc
{
    static void Main()
    {
        Console.Write("Please enter a math expression: ");
        string expr = Console.ReadLine();
        Console.WriteLine("result: {0}", Evaluate(expr));
    }

    static object Evaluate(string expr)
    {
        var compiler = new CSharpCodeProvider();
        var options = new CompilerParameters();
        options.ReferencedAssemblies.Add("system.dll");
        options.GenerateInMemory = true;

        string source = PrepareSource(expr);
        var assembly = compiler.CompileAssemblyFromSource(options, source).CompiledAssembly;
        var evaluator = assembly.CreateInstance("Evaluator");
        return evaluator.GetType().GetMethod("Evaluate").Invoke(evaluator, null);
    }

    static string PrepareSource(string expr)
    {
        expr = expr.Replace("sqrt", "Math.Sqrt").Replace("ln", "Math.Log").Replace("pow", "Math.Pow");
        return @"
        using System;
        public class Evaluator
        {
            public double Evaluate()
            {
                return expression;
            }
        }".Replace("expression", expr);
    }
}
