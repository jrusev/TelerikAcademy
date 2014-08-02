namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using System.Collections.Generic;

    public abstract class CarRepositoryMock : ICarsRepositoryMock
    {
        public CarRepositoryMock()
        {
            this.PopulateFakeData();
            this.ArrangeCarsRepositoryMock();
        }

        public ICarsRepository CarsRepo { get; protected set; }

        protected ICollection<Car> FakeCars { get; private set; }

        private void PopulateFakeData()
        {
            this.FakeCars = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };
        }

        protected abstract void ArrangeCarsRepositoryMock();
    }
}
