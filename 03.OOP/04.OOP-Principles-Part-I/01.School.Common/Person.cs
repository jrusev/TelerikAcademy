namespace School
{
    using System;

    // Both teachers and students are people.
    public abstract class Person
    {
        private string name;

        protected Person(string name)
        {
            this.Name = name;
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be null or empty!");
                }

                this.name = value;
            }
        }
    } 
}