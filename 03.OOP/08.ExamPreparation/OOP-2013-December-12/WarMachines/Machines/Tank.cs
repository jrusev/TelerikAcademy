namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using WarMachines.Interfaces;

    public class Tank : ITank
    {
        // (name) (attack) (defense)
        public Tank(string name, double attackPoints, double defensePoints)
        {
            this.HealthPoints = 100;
            this.DefenseMode = true;
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; private set; }

        public double DefensePoints { get; private set; }

        public bool DefenseMode { get; private set; }

        public string Name { get; set; }

        public IPilot Pilot { get; set; }

        public IList<string> Targets { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
        }

        public void Attack(string target)
        {
            Console.WriteLine("Attack not implemented");
        }
    }
}
