namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using Moq;
    using System.Linq;

    public class MoqCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepo = new Mock<ICarsRepository>();

            mockedCarsRepo.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepo.Setup(r => r.All()).Returns(this.FakeCars);
            mockedCarsRepo.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCars.Where(c => c.Make == "BMW").ToList());

            // New mocked methods
            mockedCarsRepo.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) => this.FakeCars.FirstOrDefault(c => c.Id == id));
            mockedCarsRepo.Setup(r => r.SortedByYear()).Returns(this.FakeCars);
            mockedCarsRepo.Setup(r => r.SortedByMake()).Returns(this.FakeCars);

            this.CarsRepo = mockedCarsRepo.Object;
        }
    }
}
