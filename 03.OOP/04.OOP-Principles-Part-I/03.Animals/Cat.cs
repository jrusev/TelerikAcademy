namespace Animals
{
    public class Cat : Animal
    {
        private readonly string sound = "Mayauu!"; 

        public Cat(string name, bool isMale, byte age)
            : base(name, isMale, age)
        {
        }

        public override void MakeSound()
        {
            System.Console.WriteLine(this.sound);
        }
    }
}
