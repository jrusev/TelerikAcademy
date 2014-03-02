namespace WarMachines.Machines
{
    using System;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 100;
            this.DefenseMode = true;

            // Tank’s defense mode adds 30 defense points to the initial ones
            // and removes 40 attack points from the initial ones. 
            if (this.DefenseMode)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
        }

        public bool DefenseMode { get; private set; }
        
        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;

            if (this.DefenseMode)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
            else
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
        }
    }
}