using System;

class Program
{
    static void Main(string[] args)
    {
        // Call DisplayWelcome with no parameters
        DisplayWelcome();

        // Get the user's name and save it
        string userName = PromptUserName();

        // Get the user's favorite number and save it
        int userNumber = PromptUserNumber();

        // Square the number and save the result
        int squaredNumber = SquareNumber(userNumber);

        // Display the results
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
