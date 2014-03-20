using System;
using ExpressionEvaluation;

class ExpressionCalc
{
    static void Main()
    {
        // Write a program that calculates the value of given arithmetical expression.
        // The expression can contain the following elements only:
        // Real numbers, e.g. 5, 18.33, 3.14159, 12.6
        // Arithmetic operators: +, -, *, / (standard priorities)
        // Mathematical functions: ln(x), sqrt(x), pow(x,y)
        // Brackets (for changing the default priorities)
        // 	Examples:
        // 	(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) = 10.60...
        // 	pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) = 21.22...

        Console.Write("Please enter a math expression: ");
        string expression = Console.ReadLine();

        ExpressionEvaluator expressionEvaluator = new ExpressionEvaluator();
        double result = 0;
        if (expressionEvaluator.TryEvaluate(expression, out result))
        {
            Console.WriteLine("result: {0}", result);
        }
        else
        {
            Console.WriteLine("Incorrect expression!");
        }
    }
}

// This is the shortest possible solution to this problem (80 lines without the comments):
// 
// In C# we can simply write:
// Console.WriteLine((3 + 5.3) * 2.7 - Math.Log(22) / Math.Pow(2.2, -1.7));
// ... and it will print the calculated result on the console.
// But at compile time (when we write the program), we don't know what the expression is.
// However, we can dynamically (at runtime) compile code from a string, load it into memory and call methods from it through reflection.
// And this is what we do - we prepare a small piece of source code in a string
// ... and simply replace a piece of it with the expression the user entered from the console at runtime.
// We compile this code, create an instance of it and call the method which contains the expression.
// The method will return the calculated expression.
// Note that we cannot get the reverse polish notation of the expression (and we don't need it), only the result
// Thanks to Nikolay Kostov!
namespace ExpressionEvaluation
{
    using System.CodeDom.Compiler;
    using System.Reflection;
    using System.Text;
    using Microsoft.CSharp;

    public class IncorrectExpressionException : Exception
    {
        // Redefine the constructor and message as needed
    }

    public class ExpressionEvaluator
    {
        // This is the source code that is sent to the C# code compiler
        // "{0}" is replaced with the math expression
        private const string codeFormat = @"
        using System;
        namespace ExpressionEvaluation
        {
            public class EvaluatorHelper
            {
                public double Evaluate()
                {
                    return {0};
                }
            }
        }";
        private CSharpCodeProvider cSharpCodeProvider; // Provides access to the C# code compiler
        private CompilerParameters cp; // Represents the parameters used to invoke a compiler

        // Replaces mathematical functions in the expression with their C# equivalents (from System.Math)
        private string PrepareExpression(string expression)
        {
            StringBuilder expressionBuilder = new StringBuilder(expression);
            expressionBuilder.Replace("sqrt", "Math.Sqrt");
            expressionBuilder.Replace("ln", "Math.Log");
            expressionBuilder.Replace("pow", "Math.Pow");
            return codeFormat.Replace("{0}", expressionBuilder.ToString());
        }

        // Constructor (initializes an instance of the CSharpCodeProvider class)
        public ExpressionEvaluator()
        {
            cSharpCodeProvider = new CSharpCodeProvider();
            cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("system.dll"); // Adds reference to system.dll needed by the source to compile
            cp.GenerateInMemory = true; // The compiler should generate the output in memory (instead of a physical file)
        }

        // Calls Evaluate(expression) and catches exceptions
        public bool TryEvaluate(string expression, out double result)
        {
            try
            {
                result = this.Evaluate(expression);
                return true;
            }
            catch (IncorrectExpressionException)
            {
                result = 0;
                return false;
            }
        }

        // Compiles an assembly from the source code containing the expression and calls its Evaluate method
        // The method will return the calculated result
        public double Evaluate(string expression)
        {
            try
            {
                expression = this.PrepareExpression(expression);
                CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(cp, expression);
                Assembly assembly = compilerResults.CompiledAssembly;
                object instance = assembly.CreateInstance("ExpressionEvaluation.EvaluatorHelper");
                object invokeResult = instance.GetType().GetMethod("Evaluate").Invoke(instance, null);
                double result = 0;
                double.TryParse(invokeResult.ToString(), out result);
                return result;
            }
            catch
            {
                throw new IncorrectExpressionException();
            }
        }
    }
}