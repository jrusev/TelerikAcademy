using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    // The Zombie should be an animal and should not be able to eat.
    public class Zombie : Animal
    {
        private const int InitialSize = 0;
        private const int MeatFromKill = 10;

        public Zombie(string name, Point location)
            : base(name, location, Zombie.InitialSize)
        {
        }

        // When a carnivore (of the so-far existing) tries to eat a Zombie,
        // it should always succeed and receive 10 meat from the Zombie.
        // However, the Zombie should never die. 
        public override int GetMeatFromKillQuantity()
        {
            //this.IsAlive = false;
            return Zombie.MeatFromKill;
        }
    }
}