namespace CommandPatterns
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        internal static void Main()
        {
            // Create user and let her compute
            User user = new User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands
            user.Undo(4);

            // Redo 3 commands
            user.Redo(3);

            // Wait for user
            Console.ReadKey();
        }
    }

    // The 'Command' abstract class
    internal abstract class Command
    {
        public abstract void Execute();

        public abstract void UnExecute();
    }

    // The 'ConcreteCommand' class
    internal class CalculatorCommand : Command
    {
        private char @operator;
        private int operand;
        private Calculator calculator;

        public CalculatorCommand(Calculator calculator, char @operator, int operand)
        {
            this.calculator = calculator;
            this.@operator = @operator;
            this.operand = operand;
        }

        // Gets operator
        public char Operator
        {
            set { this.@operator = value; }
        }

        // Get operand
        public int Operand
        {
            set { this.operand = value; }
        }

        // Execute new command
        public override void Execute()
        {
            this.calculator.Operation(this.@operator, this.operand);
        }

        // Unexecute last command
        public override void UnExecute()
        {
            var undoOperator = this.Undo(this.@operator);
            this.calculator.Operation(undoOperator, this.operand);
        }

        // Returns opposite operator for given operator
        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default: throw new
                 ArgumentException("@operator");
            }
        }
    }

    // The 'Receiver' class
    internal class Calculator
    {
        private int curr = 0;

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+':
                    this.curr += operand;
                    break;
                case '-':
                    this.curr -= operand;
                    break;
                case '*':
                    this.curr *= operand;
                    break;
                case '/':
                    this.curr /= operand;
                    break;
            }

            Console.WriteLine("Current value = {0,3} (following {1} {2})", this.curr, @operator, operand);
        }
    }

    // The 'Invoker' class
    internal class User
    {
        private Calculator calculator = new Calculator();
        private List<Command> commands = new List<Command>();
        private int current = 0;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            for (int i = 0; i < levels; i++)
            {
                if (this.current < this.commands.Count - 1)
                {
                    Command command = this.commands[this.current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            for (int i = 0; i < levels; i++)
            {
                if (this.current > 0)
                {
                    Command command = this.commands[--this.current] as Command;
                    command.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            Command command = new CalculatorCommand(this.calculator, @operator, operand);
            command.Execute();

            // Add command to undo list
            this.commands.Add(command);
            this.current++;
        }
    }
}