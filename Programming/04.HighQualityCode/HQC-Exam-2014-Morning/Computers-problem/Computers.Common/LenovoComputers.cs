namespace Computers.Common
{
    using System.Collections.Generic;

    public class LenovoComputers : ComputerFactory
    {
        public override ComputerPC MakePC()
        {
            // PC – 64 bit CPU with 2 cores, 4GB RAM, one 2000GB hard drive and monochrome video card.
            var ram = new Ram(4);
            var hardDrive = new HardDrive(2000, false, 0);

            ComputerPC pc = new ComputerPC(new Cpu(2, 64, ram), ram, new[] { new HardDrive(2000, false, 0) }, hardDrive, null, new Videocard(true));
            return pc;
        }

        public override ComputerServer MakeServer()
        {
            // Server – 128 bit CPU with 2 cores, 8GB RAM, one Raid with two 500GB hard drives.
            var ram = new Ram(8);
            var serverHDD = new HardDrive();
            ComputerServer server = new ComputerServer(
                new Cpu(2, 128, ram),
                ram,
                new List<HardDrive>
                {
                        new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(500, false, 0), new HardDrive(500, false, 0) })
                },
                serverHDD,
                null,
                new Videocard(true));

            return server;
        }

        public override ComputerLaptop MakeLaptop()
        {
            // Laptop – 64 bit CPU with 2 cores, 16GB RAM, one 1000GB hard drive, colorful video card and laptop battery. 
            var ram = new Ram(16);
            var laptopHDD = new HardDrive();

            ComputerLaptop laptop = new ComputerLaptop(
                new Cpu(2, 64, ram),
                ram,
                new[] { new HardDrive(1000, false, 0) },
                laptopHDD,
                new LaptopBattery(),
                new Videocard());

            return laptop;
        }
    }
}