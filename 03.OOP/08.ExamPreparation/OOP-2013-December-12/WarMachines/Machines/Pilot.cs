namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name {get; private set;}

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            // (pilot name) – (number of machines/”no”) (“machine”/”machines”)
            if (this.machines.Count > 0)
            {
                string str = string.Format(
                    "{0} - {1} {2}",
                    this.Name,
                    this.machines.Count,
                    this.machines.Count == 1 ? "machine" : "machines");
                report.AppendLine(str);

                foreach (var machine in this.machines)
                {
                    report.AppendLine(machine.ToString());
                }

                string s = report.ToString().TrimEnd(Environment.NewLine.ToCharArray());
                
                report = new StringBuilder(s);
            }
            else
            {
                string str = string.Format("{0} - no machines", this.Name);
                report.Append(str);
            }

            return report.ToString();
        }
    }
}