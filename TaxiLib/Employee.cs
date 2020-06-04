using System;

namespace TaxiLib
{
    public abstract class Employees 
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public decimal CarRate { get; set; }
        public string StartWork { get; set; }
        public string EndWork { get; set; }
        public string Car { get; set; }
        public Employees(string name, string startWork, string endWork, decimal carRate, string car)
        {
            Name = name;
            StartWork = startWork;
            EndWork = endWork;
            CarRate = carRate;
            Car = car;
        }
        protected abstract decimal CalculateSalary();
        
        public override string ToString()
        {
            return string.Format("Name: {0}, Working time: from {1} to {2}, Salary: {3}, Car: {4}", Name, StartWork, EndWork, Salary, Car);
        }
        public Employees()
        {

        }




    }
    public class Worker : Employees
    {

        public Worker(string name, string startWork, string endWork, decimal carRate, string car) : base(name, startWork, endWork, carRate, car)
        {
            CalculateSalary();
        }
        protected override  decimal CalculateSalary()
        {
            TimeSpan duration = DateTime.Parse(EndWork).Subtract(DateTime.Parse(StartWork));
            Salary += Math.Abs(Convert.ToDecimal(duration.TotalHours) * CarRate);
            return Salary;
        }

        public Worker() : base()
        {

        }
    }
    
    
    
}
