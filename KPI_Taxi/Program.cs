using System;
using TaxiLib;

namespace KPI_Taxi
{
    class Program
    {

        static void Main(string[] args)
        {

            /**************************************************/
            ConsoleKeyInfo key;
            TaxiPark TaxiPark = new TaxiPark("KPI_Taxi");
            bool register = false;
            string in_str = string.Empty;
            double money;
            decimal distance;
            string day = DateTime.Today.DayOfWeek.ToString();            
            string car = "car";
            

            /**************************************************/
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\tHello! Welcome to our KPI_Taxi");
            Console.WriteLine();
            Console.ResetColor();
            while (true)
            {
                Client client = new Client();
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine("Press 'S' to get started with our company");
                Console.WriteLine("Press 'W' to see the list of our workers and clients");
                Console.WriteLine("Press 'Q' to quit ");
                Console.WriteLine("Press 'R' to restart ");           
                Console.WriteLine("Press 'C' to clear the console");
                Console.ResetColor();

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.Q) break;
                if (key.Key == ConsoleKey.R) continue;
                if (key.Key == ConsoleKey.C) Console.Clear();
                /**************************************************/
                if (key.Key == ConsoleKey.W)
                {
                    Console.WriteLine();
                    TaxiPark.WorkerInfo();
                    Console.WriteLine();
                    TaxiPark.ClientInfo();
                    continue;
                }
                /**************************************************/
                if (key.Key == ConsoleKey.S)
                {
                    Console.WriteLine("\nDear client, please input your name:");
                    while (true)
                    {

                        in_str = Console.ReadLine();
                        try
                        {
                            if (in_str == string.Empty)
                            {
                                throw new ArgumentException(message: "Name is empty");
                            }
                            else
                            {
                                client.Name = in_str;
                                break;
                            }

                        }
                        catch (ArgumentException exeption)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(exeption.Message);
                            Console.ResetColor();
                        }

                        Console.WriteLine("Please enter your name again");

                    }
                    client.Name = in_str;

                    Console.WriteLine("Are you already registered? Enter 'Yes' or 'No' ");
                    while (true)
                    {
                        in_str = Console.ReadLine();
                        if (in_str == "Yes" || in_str == "yes")
                        {
                            register = true;
                            break;
                        }
                        else if (in_str == "No" || in_str == "no")
                        {
                            register = false;
                            break;
                        }
                        Console.WriteLine("Sorry, but you entered something wrong. Try again");
                    }
                    client.Registration = register;
                    /**************************************************/
                    Console.WriteLine("Please, enter state of your account: ");
                    while (true)
                    {
                        in_str = Console.ReadLine();
                        if ((double.TryParse(in_str, out money)))
                        {
                            break;
                        }

                        Console.WriteLine("Sorry, but you entered something wrong. Try again");
                    }
                    client.Account = money;
                }

                else
                {
                    Console.WriteLine(); 
                    continue;
                }
                /**************************************************/
                Console.WriteLine("Press 'Enter' to order our taxi, or something else to return to menu");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please, input a distance of your trip:");
                    while (true)
                    {
                        in_str = Console.ReadLine();
                        if (decimal.TryParse(in_str, out distance))
                        {
                            
                            break;
                        }
                        Console.WriteLine("Sorry, but you entered something wrong. Try again");
                    }
                    /**************************************************/
                    Console.WriteLine();
                    Console.WriteLine("Now you must choose a car. Enter a number:");
                    Console.WriteLine("1. CarX \t 2. Prime  \t 3. Bus \t 4. Green");
                    while (true)
                    {
                        int i = 0;
                        try
                        {
                            i = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Not a number");
                        }
                        if (i >= 1 && i <= 4)
                        {
                            switch (i)
                            {
                                case 1:
                                    car = "CarX";
                                    break;
                                case 2:
                                    car = "Prime";
                                    break;
                                case 3:
                                    car = "Bus";
                                    break;
                                case 4:
                                    car = "Green";
                                    break;
                            }
                            break;
                        }
                        Console.WriteLine("Sorry, but you entered something wrong. Try again");
                    }
                    
                    Console.WriteLine("Thanks for choosing us!");
                    
                    client.Order(distance, day, car);
                    TaxiPark.ClientAccount(client);                  
                }

                else continue;
            }
        }
    }
}


