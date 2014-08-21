namespace Computers.Common
{
    using System.Collections.Generic;

    public class HPComputers : ComputerFactory
    {
        public override ComputerPC MakePC()
        {
            ComputerPC pc;

            var ram = new Ram(2);
            var hardDrive = new HardDrive();

            pc = new ComputerPC(new Cpu(2, 32, ram), ram, new[] { new HardDrive(500, false, 0) }, hardDrive, null, new Videocard());

            return pc;
        }

        public override ComputerServer MakeServer()
        {
            ComputerServer server;

            var serverRam = new Ram(12);
            var serverHDD = new HardDrive();

            var hardDrives = new List<HardDrive>
                {
                    new HardDrive(
                        0,
                        true,
                        2,
                        new List<HardDrive>
                        { 
                            new HardDrive(1000, false, 0), new HardDrive(1000, false, 0) 
                        })
                };

            var serverCpu = new Cpu(4, 32, serverRam);

            server = new ComputerServer(
                serverCpu,
                serverRam,
                hardDrives,
                serverHDD,
                null, 
                new Videocard(true));

            return server;
        }

        public override ComputerLaptop MakeLaptop()
        {
            ComputerLaptop laptop;

            var laptopHDD = new HardDrive();
            var ram1 = new Ram(4);

            laptop = new ComputerLaptop(
                new Cpu(2, 64, ram1),
                ram1,
                new[] { new HardDrive(500, false, 0) },
                laptopHDD,
                new LaptopBattery(),
                new Videocard());

            return laptop;
        }
    }
}
