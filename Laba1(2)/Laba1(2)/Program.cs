using System;
using System.Collections.Generic;
using System.Linq;
namespace laba1;
class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Task 1: ");
        var parking = new Parking();
        parking.Park(2, "Kia");
        parking.Park(2, "Fiat");
        parking.Print();
        parking.Leave("Kia");
        parking.Print();


        Console.WriteLine("Task 2: ");
        Dictionary<int, string> plants = new Dictionary<int, string>();
        plants.Add(1, "Kia");
        plants.Add(2, "Fiat");
        plants.Add(3, "Kia");
        plants.Add(4, "Ford");
        plants.Add(5, "Fiat");

        foreach (var plant in plants)
        {
            Console.WriteLine(plant);
        }

        var duplicate = plants.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() > 1);
        foreach (var plant1 in duplicate)
        {
            var keys = plant1.Aggregate("", (k, v) => k + ", " + v);
            Console.WriteLine("Value is repeated for these keys:  " + plant1.Key + ":" + keys);
        }


        Console.WriteLine("Task 3: ");
        var random = new Random();
        var listOfNumbers = new List<int>();

        for (int i = 0; i < 20; i++)
        {
            listOfNumbers.Add(random.Next(30));
        }

        var selectedNumbers = from num in listOfNumbers where num >= 5 && num <= 15 select num;
        foreach (var number in selectedNumbers)
        {
            Console.WriteLine(number);
        }

        double average = selectedNumbers.Average();
        Console.WriteLine($"Average: {average}");

    }

class Parking
    {
        List<string> slots = new() { "Ford", null, "Audi", "Bmw", null, "Wv" };

        internal void Park(int slot, string car)
        {
            for (int i = slot; i < slots.Count; i++)
            {
                if (slots[i] == null)
                {
                    slots[i] = car;
                    Console.WriteLine(" Parking car " + car + " to the slot " + i);
                    return;
                }
            }
            Console.WriteLine(" No free slots for " + car);
        }

        internal void Leave(string car)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i] == car)
                {
                    slots[i] = null;
                    Console.WriteLine(" Car " + car + " leaves from the slot " + i);
                    return;
                }
            }
        }

        internal void Print()
        {
            foreach (var car in slots)
            {
                Console.WriteLine(car);
            }
        }
    }
}
