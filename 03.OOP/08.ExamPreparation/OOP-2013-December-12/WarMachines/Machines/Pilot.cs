namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        public Pilot(string name)
        {
            this.Name = name;
        }

        public string Name {get; private set;}

        public void AddMachine(IMachine machine)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}