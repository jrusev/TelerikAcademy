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
            //- (machine name)
            // *Type: (“Tank”/”Fighter”)
            // *Health: (machine health points)
            // *Attack: (machine attack points)
            // *Defense: (machine defense points)
            // *Targets: (machine target names/”None” – comma separated)
            // *Defense: (“ON”/”OFF” – when applicable)
            // *Stealth: (“ON”/”OFF” – when applicable)
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0}", this.Name));
            sb.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));



            return sb.ToString();
        }
    }
}
