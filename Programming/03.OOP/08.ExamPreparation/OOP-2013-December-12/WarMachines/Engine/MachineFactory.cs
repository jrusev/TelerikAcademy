namespace WarMachines.Engine
{
    using System;
    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class MachineFactory : IMachineFactory
    {
        public IPilot HirePilot(string name)
        {
            // Pilot (name) hired
            IPilot pilot = new Pilot(name);
            //Console.WriteLine("Pilot {0} hired", pilot.Name);
            return pilot;
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            // Tank (name) manufactured - attack: (attack); defense: (defense)
            ITank tank = new Tank(name, attackPoints, defensePoints);
            //Console.WriteLine("Tank {0} manufactured - attack: {1}; defense: {2}", tank.Name, tank.AttackPoints, tank.DefensePoints);
            return tank;
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            // Fighter (name) manufactured - attack: (attack); defense: (defense); stealth: (ON/OFF)
            IFighter fighter = new Fighter(name, attackPoints, defensePoints, stealthMode);
            //Console.WriteLine("Fighter {0} manufactured - attack: {1}; defense: {2}; stealth: {3}",
            //    fighter.Name,
            //    fighter.AttackPoints,
            //    fighter.DefensePoints,
            //    fighter.StealthMode ? "ON" : "OFF");
            return fighter;
        }
    }
}
