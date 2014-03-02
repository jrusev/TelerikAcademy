namespace WarMachines.Machines
{
    using System;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints,defensePoints)
        {
            this.HealthPoints = 100;
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
        }
    }
}
