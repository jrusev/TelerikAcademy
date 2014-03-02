namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using WarMachines.Interfaces;

    public class Fighter : IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            this.HealthPoints = 200;
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public string Name {get; set; }

        public IPilot Pilot {get; set; }

        public double HealthPoints {get; set; }

        public double AttackPoints { get; private set; }

        public double DefensePoints { get; private set; }

        public IList<string> Targets { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public void Attack(string target)
        {
            Console.WriteLine("Attack not implemented");
        }
    }
}
