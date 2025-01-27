using System;

class Program
{
    static void Main(string[] args)
    {
        // Variable to control playing again
        string playAgain = "yes";

        // Main game loop
        while (playAgain.ToLower() == "yes")
        {
            // Generate random number between 1 and 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            // Initialize variables for game loop
            int guess;
            int guessCount = 0;
            bool guessedCorrectly = false;

            // Game introduction
            Console.WriteLine("\nI have picked a number between 1 and 100.");

            // Keep asking for guesses until correct
            while (!guessedCorrectly)
            {
                // Get user's guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                // Check the guess
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    guessedCorrectly = true;
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask to play again
            Console.Write("\nWould you like to play again (yes/no)? ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("\nThanks for playing! Goodbye.");
    }
}
