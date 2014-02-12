namespace Human
{
    // Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay,
    // and method MoneyPerHour() that returns money earned by hour by the worker.
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public int WeekSalary { get; set; }

        public int WorkHoursPerDay { get; set; }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (5m * this.WorkHoursPerDay);
        }

        public override string ToString()
        {
            return string.Format("{0,-20} USD/hr: {1:F2}", base.ToString(), this.MoneyPerHour());
        }
    }
}