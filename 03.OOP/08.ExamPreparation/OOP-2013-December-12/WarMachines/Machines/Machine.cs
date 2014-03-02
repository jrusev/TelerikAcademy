namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Machine : IMachine
    {
        private string name;
        private IPilot pilot;

        // (name) (attack) (defense)
        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

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
                    throw new ApplicationException("The name of the machine cannot be null or empty string!");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value == null)
                {
                    throw new ApplicationException("The machine cannot be engaged with null pilot!");
                }

                this.pilot = value;
            }
        }

        public IList<string> Targets { get; private set; }

        public void Attack(string target)
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                throw new ApplicationException("The attacked target cannot be null or empty string!");
            }

            this.Targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0}", this.Name));
            sb.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            sb.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            sb.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            sb.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));

            // *Targets: (machine target names/”None” – comma separated)
            sb.AppendLine(string.Format(" *Targets: {0}", this.Targets.Count > 0 ? string.Join(", ", this.Targets) : "None"));

            if (this is ITank)
            {
                bool defenseOn = (this as ITank).DefenseMode;
                sb.Append(string.Format(" *Defense: {0}", defenseOn ? "ON" : "OFF"));
            }
            else if (this is IFighter)
            {
                bool stealthOn = (this as IFighter).StealthMode;
                sb.Append(string.Format(" *Stealth: {0}", stealthOn ? "ON" : "OFF"));
            }
            else
            {
                throw new ApplicationException("Machine not supported");
            }

            return sb.ToString();
        }
    }
}