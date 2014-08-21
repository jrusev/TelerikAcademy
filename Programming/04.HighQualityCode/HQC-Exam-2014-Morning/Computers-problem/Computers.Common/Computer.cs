namespace Computers.Common
{
    using System.Collections.Generic;

    public abstract class Computer
    {
        private const string BatteryStatusFormat = "Battery status: {0}%";
        private const string WrongGuessFormat = "You didn't guess the number {0}.";
        private const string WinMessage = "You win!";
        
        private readonly LaptopBattery battery;
        private IVideocard videocard;
        private IHardDrive hardDrive;
        private Cpu cpu;
        private IRam ram;
        private IEnumerable<HardDrive> hardDrives;

        internal Computer(
            Cpu cpu,
            IRam ram,
            IEnumerable<HardDrive> hardDrives,
            IHardDrive hardDrive,
            LaptopBattery battery,
            IVideocard videocard)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.hardDrives = hardDrives;
            this.hardDrive = hardDrive;
            this.videocard = videocard;
            this.battery = battery;
        }

        public virtual void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.videocard.Draw(string.Format(BatteryStatusFormat, this.battery.Percentage));
        }

        public virtual void Play(int guessNumber)
        {
            this.cpu.Rand(1, 10);
            var number = this.ram.LoadValue();
            if (number != guessNumber)
            {
                this.videocard.Draw(string.Format(WrongGuessFormat, number));
            }
            else
            {
                this.videocard.Draw(WinMessage);
            }
        }

        public virtual void Process(int data)
        {
            this.ram.SaveValue(data);
            string result = this.cpu.SquareNumber();
            this.videocard.Draw(result);
        }
    }
}
