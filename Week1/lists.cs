using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the numbers
        List<int> numbers = new List<int>();

        // Explain the program to the user
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Get numbers from the user until they enter 0
        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            // Check if we should stop
            if (number == 0)
            {
                break;
            }

            // Add the number to our list
            numbers.Add(number);
        }

        // Core Requirement 1: Calculate the sum
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        // Core Requirement 2: Calculate the average
        if (numbers.Count > 0)
        {
            double average = numbers.Average();
            Console.WriteLine($"The average is: {average}");
        }

        // Core Requirement 3: Find the largest number
        if (numbers.Count > 0)
        {
            int largest = numbers.Max();
            Console.WriteLine($"The largest number is: {largest}");
        }

        // Stretch Challenge 1: Find smallest positive number
        var positiveNumbers = numbers.Where(n => n > 0);
        if (positiveNumbers.Any())
        {
            int smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Stretch Challenge 2: Sort and display the list
        if (numbers.Count > 0)
        {
            Console.WriteLine("The sorted list is:");
            
            // Sort the list
            numbers.Sort();

            // Display each number on a new line
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
