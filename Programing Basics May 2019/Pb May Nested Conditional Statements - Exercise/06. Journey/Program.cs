﻿using System;

namespace _06._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "Placeholder";
            string place = "Placeholder";

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    place = "Camp";
                    budget = budget * 0.30;
                }
                else if (season == "winter")
                {
                    place = "Hotel";
                    budget = budget * 0.70;
                }

            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    place = "Camp";
                    budget = budget * 0.40;
                }
                else if (season == "winter")
                {
                    place = "Hotel";
                    budget = budget * 0.80;
                }
            }
            else if (budget >= 1000)
            {
                destination = "Europe";
                place = "Hotel";
                budget = budget * 0.90;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{place} - {budget:F2}");
        }
    }
}
