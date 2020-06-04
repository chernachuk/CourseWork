using System;
using System.Collections.Generic;


namespace TaxiLib
{
    public class TaxiPark
    {
        readonly List<Worker> _workers = new List<Worker>();
        readonly List<Client> _clients = new List<Client>();
        public string Name { get; set; }

        public TaxiPark(string name)
        {
            Name = name;
            _workers = new List<Worker>
            {
                new Worker("Vadim",  "7:00 AM", "8:00 PM", 17m, "Deo Lanos"),
                new Worker("Andrey", "9:00 AM", "10:00 PM",25m, "Bmw X5"),
                new Worker("Ilia",   "11:00 AM","11:00 PM",30m, "Porshce"),
                new Worker("Mihail", "1:00 AM", "10:00 AM",22m, "Mersedes Benz"),
                new Worker("Roman",  "3:00 AM", "4:00 PM", 21m, "Smart"),
                new Worker("Nikolay","5:00 AM", "7:00 PM", 12m, "Jigul"),
                new Worker("Kiril",  "5:00 PM", "6:00 AM", 40m, "Lemousin"),
                new Worker("Vilen",  "8:00 AM", "7:00 PM", 29m, "Audi"),
                new Worker("Sanya",  "2:00 AM", "2:00 PM", 28m, "Gelik"),
                new Worker("Orest",  "4:00 AM", "5:00 PM", 24m, "Opel"),
                new Worker("Luka",   "8:00 AM", "7:00 PM", 23m, "Yoyota Corova")
            };
        }
        public void ClientAccount(Client client)

        {
            Console.WriteLine($"Dear {client.Name}, please wait, your car will arrive soon");            
            client.Pay();
            client.HashCode = GetHashCode(client.Name);
            _clients.Add(client);
        }
        public void ClientInfo()
        {
            Console.WriteLine("Our clients:");
            foreach (var cl in _clients)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(cl);
                Console.ResetColor();
            }
        }
        public void WorkerInfo()
        {
            Console.WriteLine("Our workers:");
            foreach (var w in _workers)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(w);
                Console.ResetColor();
            }
        }
        /******************************************************/
        private static int GetHashCode(string value)
        {
            int h = 0;
            for (int i = 0; i < value.Length; i++)
                h += value[i] * 31 ^ value.Length - (i + 1);
            return h;
        }
        /******************************************************/

    }
}
