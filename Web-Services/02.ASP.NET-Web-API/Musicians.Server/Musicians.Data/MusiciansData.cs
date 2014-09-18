namespace Musicians.Data
{
    using System;
    using System.Collections.Generic;

    using Musicians.Data.Repositories;
    using Musicians.Models;

    public class MusiciansData : IMusiciansData
    {
        private IMusiciansDBContext context;
        private IDictionary<Type, object> repositories;

        public MusiciansData(IMusiciansDBContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public MusiciansData()
            : this(new MusiciansDBContext())
        {
        }

        public IGenericRepository<Song> Songs
        {
            get { return this.GetRepository<Song>(); }
        }

        public IGenericRepository<Artist> Artists
        {
            get { return this.GetRepository<Artist>(); }
        }

        public IGenericRepository<Album> Albums
        {
            get { return this.GetRepository<Album>(); }
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
