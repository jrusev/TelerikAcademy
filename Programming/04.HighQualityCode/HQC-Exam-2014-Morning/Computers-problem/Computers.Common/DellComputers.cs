namespace Computers.Common
{
    using System.Collections.Generic;

    public class DellComputers : ComputerFactory
    {
        public override ComputerPC MakePC()
        {
            ComputerPC pc;
            var ram = new Ram(8);
            var hardDrive = new HardDrive();

            pc = new ComputerPC(new Cpu(4, 64, ram), ram, new[] { new HardDrive(1000, false, 0) }, hardDrive, null, new Videocard());
            return pc;
        }

        public override ComputerServer MakeServer()
        {
            ComputerServer server;

            var ram = new Ram(64);
            var serverHDD = new HardDrive();
            server = new ComputerServer(
                new Cpu(8, 64, ram),
                ram,
                new List<HardDrive>
                {
                    new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(2000, false, 0), new HardDrive(2000, false, 0) })
                },
                serverHDD,
                null,
                new Videocard(true));

            return server;
        }

        public override ComputerLaptop MakeLaptop()
        {
            ComputerLaptop laptop;

            var ram = new Ram(8);
            var hardDrive = new HardDrive();

            laptop = new ComputerLaptop(
                new Cpu(4, 32, ram),
                ram,
                new[] { new HardDrive(1000, false, 0) },
                hardDrive,
                new LaptopBattery(),
                new Videocard());

            return laptop;
        }
    }
}