namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, byte age)
            : base(name, false, age)
        {
        }

        public override void MakeSound()
        {
            System.Console.Write("I am a kitty. ");
            base.MakeSound();
        }
    }
}