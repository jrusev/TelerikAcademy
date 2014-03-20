using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int InitialSize = 6;
        private int growSizeBy;

        public Lion(string name, Point location)
            : base(name, location, Lion.InitialSize)
        {
            this.growSizeBy = 1;
        }

        public int TryEatAnimal(Animal animal)
        {
            // The Lion should be able to eat any animal, which is at most twice larger than him (inclusive).
            // Also, the Lion should grow by 1 with each animal it eats.
            if (animal != null && animal.Size <= 2 * this.Size)
            {
                this.Size += this.growSizeBy;
                return animal.GetMeatFromKillQuantity();
            }
            else
            {
                return 0;
            }
        }
    }
}
