namespace Computers.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDrive : Computers.Common.IHardDrive
    {
        private bool isInRaid;
        private int hardDrivesInRaid;

        private int capacity;
        private Dictionary<int, string> data;
        private IEnumerable<HardDrive> hardDrives;

        internal HardDrive()
        {
        }

        internal HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;

            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
            this.hardDrives = new List<HardDrive>();
        }

        internal HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid, List<HardDrive> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;

            this.data = new Dictionary<int, string>(capacity);
            this.hardDrives = new List<HardDrive>();
            this.hardDrives = hardDrives;
        }

        public int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hardDrives.Any())
                    {
                        return 0;
                    }

                    return this.hardDrives.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }
        }

        public void SaveData(int addr, string data)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.hardDrives)
                {
                    hardDrive.SaveData(addr, data);
                }
            }
            else
            {
                this.data[addr] = data;
            }
        }

        public string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (!this.hardDrives.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.hardDrives.First().LoadData(address);
            }
            else
            {
                return this.data[address];
            }
        }
    }
}
