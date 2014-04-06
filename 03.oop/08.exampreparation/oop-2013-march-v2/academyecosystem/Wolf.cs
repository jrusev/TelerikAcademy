using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        private const int InitialSize = 4;

        public Wolf(string name, Point location)
            : base(name, location, Wolf.InitialSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            // Wolf should be able to eat any animal smaller than or as big as him,
            // or any animal which is sleeping.
            if (animal != null && (animal.Size <= this.Size || animal.State == AnimalState.Sleeping))
            {
                return animal.GetMeatFromKillQuantity();
            }
            else
            {
                return 0;
            }
        }
    }
}
