namespace Computers.Common
{
    using System;

    public class Videocard : Computers.Common.IVideocard
    {
        public Videocard(bool isMonochrome = false)
        {
            this.IsMonochrome = isMonochrome;
        }

        public bool IsMonochrome { get; private set; }

        public void Draw(string text)
        {
            if (this.IsMonochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(text);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                Console.ResetColor();
            }
        }
    }
}
