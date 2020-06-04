using System;


namespace TaxiLib
{
    public abstract class Clients
    {
        public string Name { get; set; } = "name";
        public bool Registration { get; set; }
        public double Account { get; set; }
        public int HashCode { get; set; }
        public Clients(string name, bool registration, double money)
        {
            Name = name;
            Registration = registration;
            Account = money;
        }
        public Clients()
        {

        }

        public abstract void Order(decimal distance, string day, string car);
        public abstract void Pay();
        public override string ToString()
        {
            return string.Format("Name: {0}, Id: {1}", Name, HashCode);
        }
    }

    public delegate void MyEventHandler();
    public class Client : Clients
    {
        public event MyEventHandler SomethingHappened;
        public Ride ride = new Ride();
        public event Action Notify;
        public Client(string name, bool Registration, double money) : base(name, Registration, money)
        {
            if (Registration) ride.Price -= ride.Price * 0.15;
        }
        public Client() : base()
        {

        }

       
        public override void Order(decimal distance, string day, string car)
        {
            ride.Distance = distance;
            ride.Day = day;
            if (car == "CarX") { }
            if (car == "Prime") { ride.Price += ride.Price; }
            if (car == "Bus") { ride.Price -= ride.Price * 0.2; }
            if (car == "Green") { ride.Price += ride.Price*0.15; }
            ride.Car = car;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your order is confirmed!");
            Console.ResetColor();

            if (Registration) Console.WriteLine($"{Name}, as our regular customer you will get a discount 15%");
            Notify?.Invoke();
            if (!ride.rides.Contains(ride))
            {
                ride.rides.Add(ride);
            }

            foreach (Ride ride in ride.rides)
            {
                ride.PrintInfo();
            }

        }
        public override void Pay()
        {

            if (Account >= ride.Price)
            {
                Account -= ride.Price;
                SomethingHappened += AccountState;
                SomethingHappened?.Invoke();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name},sorry, but you dont't have enough money");
                Console.ResetColor();
            }

        }

        private void AccountState()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"After you paid for the order you have left {Account}, have a nice day!");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
