using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.WriteLine("Enter a number:");
            string userNum = Console.ReadLine();
            int number = int.Parse(userNum);

            if 
            (number == 0)
            {
                break;
            }
            numbers.Add(number);
        }

        if (numbers.Count > 0)
        {
            int total = numbers.Sum();
            double average = numbers.Average();
            int largest = numbers.Max();

            Console.WriteLine($"The sum is: {total}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {largest}");
        }
        else
        {
            Console.WriteLine("No numbers entered.");
        }
    }
}