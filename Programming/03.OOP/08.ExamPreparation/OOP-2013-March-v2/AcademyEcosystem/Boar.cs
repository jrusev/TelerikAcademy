using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private const int InitialSize = 4;
        private int biteSize;
        private int growSizeBy;

        public Boar(string name, Point location)
            : base(name, location, Boar.InitialSize)
        {
            this.biteSize = 2;
            this.growSizeBy = 1;
        }

        public int TryEatAnimal(Animal animal)
        {
            // The Boar should be able to eat any animal, which is smaller than him or as big as him.
            if (animal != null && animal.Size <= this.Size)
            {
                return animal.GetMeatFromKillQuantity();
            }
            else
            {
                return 0;
            }
        }

        // The Boar should be able to eat from any plant.
        // When eating from a plant, the Boar increases its size by 1.
        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size += this.growSizeBy;
                return plant.GetEatenQuantity(this.biteSize);
            }
            else
            {
                return 0;
            }            
        }
    }
}