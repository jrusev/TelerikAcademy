namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        // Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).
        private static void Main()
        {
            IEnumerable<Animal> dogs = new Dog[]
            {
                new Dog("Rex", true, 3),
                new Dog("Lassy", false, 4),
            };

            IEnumerable<Frog> frogs = new List<Frog>()
            {
                new Frog("Twig", true, 2),
                new Frog("Greenie", false, 8),
            };

            IEnumerable<Animal> tomcats = new List<Tomcat>()
            {
                new Tomcat("Tommy", 5)
            };

            IEnumerable<Animal> kittens = new List<Kitten>()
            {
                new Kitten("Kitty", 4)
            };

            IEnumerable<Animal> animals = new List<Animal>().Concat(dogs).Concat(frogs).Concat(tomcats).Concat(kittens);

            Console.WriteLine("ALL ANIMALS");
            Console.WriteLine("============");
            Console.WriteLine(string.Join(Environment.NewLine, animals));

            var grouped = animals.GroupBy(a => a.GetType());
            Console.WriteLine("\nAverage age of each kind:");
            foreach (var kind in grouped)
            {
                Console.WriteLine("{0,-7} - {1:F1}", kind.Key.Name + 's', kind.Average(x => x.Age));
            }

            Console.WriteLine("\nLet's make some noise...");
            foreach (var animal in animals)
            {
                Console.Write("{0} says: ", animal.Name);
                animal.MakeSound();
            }
        }
    }
}