namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using System.Linq;
    using Telerik.JustMock;

    public class JustMockCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => this.CarsRepo.Add(Arg.IsAny<Car>())).DoNothing();
            Mock.Arrange(() => this.CarsRepo.All()).Returns(this.FakeCars);
            Mock.Arrange(() => this.CarsRepo.Search(Arg.AnyString)).Returns(this.FakeCars.Where(c => c.Make == "BMW").ToList());

            // New mocked methods
            Mock.Arrange(() => this.CarsRepo.GetById(Arg.AnyInt)).Returns((int id) => this.FakeCars.FirstOrDefault(c => c.Id == id));
            Mock.Arrange(() => this.CarsRepo.SortedByYear()).Returns(this.FakeCars);
            Mock.Arrange(() => this.CarsRepo.SortedByMake()).Returns(this.FakeCars);
        }
    }
}
