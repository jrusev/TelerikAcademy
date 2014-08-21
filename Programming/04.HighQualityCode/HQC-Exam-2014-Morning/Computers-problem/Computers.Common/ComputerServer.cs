namespace Computers.Common
{
    using System.Collections.Generic;

    public class ComputerServer : Computer
    {
        public ComputerServer(
            Cpu cpu,
            Ram ram,
            IEnumerable<HardDrive> hardDrives,
            HardDrive hardDrive,
            LaptopBattery battery,
            Videocard videocard)
            : base(cpu, ram, hardDrives, hardDrive, battery, videocard)
        {
        }
    }
}
