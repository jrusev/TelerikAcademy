namespace Human
{
    using System;

    internal static class RandomNames
    {
        private static readonly Random Rand = new Random();
        
        public static string RandFirstName()
        {
            string[] firstNames =
            {
                "Jacob       ",
                "Michael     ",
                "Matthew     ",
                "Joshua      ",
                "Christopher ",
                "Nicholas    ",
                "Andrew      ",
                "Joseph      ",
                "Daniel      ",
                "Tyler       ",
                "William     ",
                "Brandon     ",
                "Ryan        ",
                "John        ",
                "Zachary     ",
                "David       ",
                "Anthony     ",
                "James       ",
                "Justin      ",
                "Alexander   ",
                "Emily       ",
                "Hannah      ",
                "Madison     ",
                "Ashley      ",
                "Sarah       ",
                "Alexis      ",
                "Samantha    ",
                "Jessica     ",
                "Elizabeth   ",
                "Taylor      ",
                "Lauren      ",
                "Alyssa      ",
                "Kayla       ",
                "Abigail     ",
                "Brianna     ",
                "Olivia      ",
                "Emma        ",
                "Megan       ",
                "Grace       ",
                "Victoria    ",
            };
            return firstNames[Rand.Next(firstNames.Length)].TrimEnd();
        }

        public static string RandSecondName()
        {
            string[] secondNames =
            {
                "Smith      ",
                "Johnson    ",
                "Williams   ",
                "Brown      ",
                "Jones      ",
                "Miller     ",
                "Davis      ",
                "García     ",
                "Rodríguez  ",
                "Wilson     ",
                "Martínez   ",
                "Anderson   ",
                "Taylor     ",
                "Thomas     ",
                "Hernández  ",
                "Moore      ",
                "Martin     ",
                "Jackson    ",
                "Thompson   ",
                "White      ",
                "López      ",
                "Lee        ",
                "González   ",
                "Harris     ",
                "Clark      ",
                "Lewis      ",
                "Robinson   ",
                "Walker     ",
                "Pérez      ",
                "Hall       ",
                "Young      ",
                "Allen      ",
                "Sánchez    ",
                "Wright     ",
                "King       ",
                "Scott      ",
                "Green      ",
                "Baker      ",
                "Adams      ",
                "Nelson     ",
            };
            return secondNames[Rand.Next(secondNames.Length)].TrimEnd();
        }
    }
}