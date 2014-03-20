namespace Animals
{
    public class Dog : Animal
    {
        private readonly string sound = "Wow!";

        public Dog(string name, bool isMale, byte age)
            : base(name, isMale, age)
        {
        }

        public override void MakeSound()
        {
            System.Console.WriteLine(this.sound);
        }
    }
}
