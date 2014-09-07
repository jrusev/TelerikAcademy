namespace Academy.Data
{
    using System;
    using System.Collections.Generic;

    using Academy.Data.Repositories;
    using Academy.Models;

    public class AcademyData : IAcademyData
    {
        private IAcademyDBContext context;
        private IDictionary<Type, object> repositories;

        public AcademyData(IAcademyDBContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public AcademyData()
            : this(new AcademyDBContext())
        {
        }

        public IGenericRepository<Course> Courses
        {
            get { return this.GetRepository<Course>(); }
        }

        public IGenericRepository<Homework> Homeworks
        {
            get { return this.GetRepository<Homework>(); }
        }

        public IGenericRepository<Student> Students
        {
            get { return this.GetRepository<Student>(); }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
