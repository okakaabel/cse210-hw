using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Print empty line for spacing
        Console.WriteLine();

        // Display the name in James Bond style format
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
