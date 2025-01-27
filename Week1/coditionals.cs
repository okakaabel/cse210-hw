using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for grade percentage
        Console.Write("Enter your grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());

        // Variables to store the letter grade and sign
        string letter;
        string sign = "";

        // Determine the letter grade
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign (stretch challenge 1, 2, and 3)
        if (letter != "F") // No signs for F grade
        {
            int lastDigit = percentage % 10;
            
            if (lastDigit >= 7)
            {
                // Special case for A grade (stretch challenge 2)
                if (letter != "A")
                {
                    sign = "+";
                }
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Print the final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Check if the student passed and display appropriate message
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Keep working hard. You'll do better next time!");
        }
    }
}
