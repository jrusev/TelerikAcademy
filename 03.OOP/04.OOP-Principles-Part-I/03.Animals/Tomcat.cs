namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, byte age)
            : base(name, true, age)
        {
        }

        public override void MakeSound()
        {
            System.Console.Write("I am a tomcat. ");
            base.MakeSound();
        }
    }
}