namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private IList<IMachine> machines;
        private string name;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ApplicationException("The name of the pilot cannot be null or empty string!");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ApplicationException("The machine that is added cannot be null!");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            // (pilot name) - (number of machines/"no") ("machine"/"machines")
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