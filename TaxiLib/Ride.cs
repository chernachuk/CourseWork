using System;
using System.Collections.Generic;


namespace TaxiLib
{
    public class Ride
    {
        public delegate void InfoDay();
        public event InfoDay Info;
        /*******************************************************/
        readonly public List<Ride> rides = new List<Ride>();
        
        public decimal Distance { get; set; }       
        public double Price { get; set; } = 40;
        public string Day { get; set; }
        public string Car { get; set; }
        /*******************************************************/
        public Ride(decimal distance, string day, string car)
        {
            Distance = distance;
            Day = day;
            Car = car;           
        }
        public Ride() { }
        
        public void PrintInfo()
        {
            CalcPrice();
            Console.WriteLine($"Today is {Day}, your order details: \nDistance is: {Distance} \t Car: {Car}\t Price is: {Price} UAH  ");           
            Console.WriteLine();
        }
        public void CalcPrice()
        {
            if (Distance > 1000)
                Price += Convert.ToDouble(Distance*0.05m);
            if (Day == "Saturday" || Day == "Sunday")
            {
                Price += Price * 0.5;
                Info += delegate
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Today is a weekend, so the price is increased ");
                    Console.ResetColor();
                };
                Info?.Invoke();
            }            
        }
    }
}
