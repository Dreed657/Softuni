﻿using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                int multiply = n * i;
                Console.WriteLine($"{n} X {i} = {multiply}");
            }
        }
    }
}