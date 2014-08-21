namespace Computers.Common
{
    public abstract class ComputerFactory
    {
        public abstract ComputerPC MakePC();

        public abstract ComputerServer MakeServer();

        public abstract ComputerLaptop MakeLaptop();
    }
}
