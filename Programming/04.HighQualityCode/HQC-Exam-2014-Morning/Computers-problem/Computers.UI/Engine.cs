namespace Computers
{
    using System;
    using Computers.Common;

    internal class Engine
    {
        private Computer pc, laptop, server;

        public void Run()
        {
            var manufacturer = Console.ReadLine();

            this.BuildComputers(manufacturer);

            this.ReadCommands();
        }

        private void BuildComputers(string manufacturer)
        {
            ComputerFactory factory;

            switch (manufacturer)
            {
                case "HP":
                    factory = new HPComputers();
                    break;
                case "Dell":
                    factory = new DellComputers();
                    break;
                case "Lenovo":
                    factory = new LenovoComputers();
                    break;
                default:
                    throw new ArgumentException("Invalid manufacturer!");
            }

            this.pc = factory.MakePC();
            this.server = factory.MakeServer();
            this.laptop = factory.MakeLaptop();
        }

        private void ReadCommands()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == null || input.StartsWith("Exit"))
                {
                    break;
                }

                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var command = tokens[0];
                var numberInput = int.Parse(tokens[1]);

                if (command == "Charge")
                {
                    this.laptop.ChargeBattery(numberInput);
                }
                else if (command == "Process")
                {
                    this.server.Process(numberInput);
                }
                else if (command == "Play")
                {
                    this.pc.Play(numberInput);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}
