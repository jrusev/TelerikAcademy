namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Machine : IMachine
    {
        // (name) (attack) (defense)
        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; private set; }

        public double DefensePoints { get; private set; }

        public string Name { get; set; }

        public IPilot Pilot { get; set; }

        public IList<string> Targets { get; private set; }

        public void Attack(string target)
        {
            Console.WriteLine("Attack not implemented");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0}", this.Name));
            sb.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            sb.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            sb.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));

            // *Targets: (machine target names/”None” – comma separated)
            sb.AppendLine(string.Format(" *Targets: {0}", this.Targets.Count > 0 ? string.Join(",", this.Targets) : "None"));

            if (this is ITank)
            {
                bool defenseOn = (this as ITank).DefenseMode;
                sb.AppendLine(string.Format(" *Defense: {0}", defenseOn ? "ON" : "OFF"));
            }
            else if (this is IFighter)
            {
                bool stealthOn = (this as IFighter).StealthMode;
                sb.AppendLine(string.Format(" *Stealth: {0}", stealthOn ? "ON" : "OFF"));
            }
            else
            {
                throw new ApplicationException("Machine not supported");
            }

            return sb.ToString();
        }
    }
}