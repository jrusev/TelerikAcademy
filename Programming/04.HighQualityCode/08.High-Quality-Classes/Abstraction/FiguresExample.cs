namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Console.WriteLine(new Circle(5));
            Console.WriteLine(new Rectangle(2, 3));

            try
            {
                Console.WriteLine(new Circle(-5));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine(new Rectangle(2, -3));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
