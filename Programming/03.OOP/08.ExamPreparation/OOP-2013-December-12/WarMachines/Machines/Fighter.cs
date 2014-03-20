namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 200;  
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; } 

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }    
    }
}
