namespace Animals
{
    public class Frog : Animal
    {
        private readonly string sound = "Kwak!";

        public Frog(string name, bool isMale, byte age)
            : base(name, isMale, age)
        {
        }

        public override void MakeSound()
        {
            System.Console.WriteLine(this.sound);
        }
    }
}
