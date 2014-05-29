namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine(
                "I am a circle. " + "My perimeter is {0:f2}. My surface is {1:f2}.",
                circle.Perimeter,
                circle.Surface);

            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(
                "I am a rectangle. " + "My perimeter is {0:f2}. My surface is {1:f2}.",
                rect.Perimeter,
                rect.Surface);
        }
    }
}
