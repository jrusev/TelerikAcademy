namespace Animals
{
    public abstract class Animal : ISound
    {
        protected Animal(string name, bool isMale, byte age)
        {
            this.Name = name;
            this.IsMale = isMale;
            this.Age = age;
        }

        public string Name { get; set; }

        public bool IsMale { get; set; }

        public byte Age { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-7} ({1}) Age: {2,-2}", this.Name, this.IsMale ? "M" : "F", this.Age);
        }

        public abstract void MakeSound();
    }
}
