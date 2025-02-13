using System;
using System.Threading;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Activity Program!");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Please select a choice from the menu (1-4): ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    StartBreathingActivity();
                    break;
                case "2":
                    StartReflectionActivity();
                    break;
                case "3":
                    StartListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Activity Program. Goodbye!");
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    // Breathing Activity with timer and feedback
    private static void StartBreathingActivity()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will guide you through a breathing exercise.");
        
        // Ask for duration of activity
        Console.Write("Enter the duration for this activity in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        int elapsedTime = 0;
        
        while (elapsedTime < duration)
        {
            Console.Clear();
            Console.WriteLine("Breathing in...");
            Thread.Sleep(4000);
            Console.Clear();
            Console.WriteLine("Breathing out...");
            Thread.Sleep(4000);
            elapsedTime += 8; // 4 seconds per breath in and out cycle
            DisplayProgress(elapsedTime, duration);
        }

        Console.Clear();
        Console.WriteLine("Great job! You’ve completed the breathing activity.");
        Thread.Sleep(2000);
    }

    // Reflection Activity with questions and timed pauses
    private static void StartReflectionActivity()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will guide you to reflect on your day.");
        
        string[] reflectionQuestions = {
            "What are you grateful for today?",
            "What is something you’ve learned recently?",
            "How have you grown as a person this week?",
            "What is one thing you’d like to improve?"
        };

        foreach (string question in reflectionQuestions)
        {
            Console.Clear();
            Console.WriteLine(question);
            Thread.Sleep(2000);
            Console.WriteLine("\nTake a moment to reflect and press any key when you're ready to continue...");
            Console.ReadKey();
        }

        Console.Clear();
        Console.WriteLine("Reflection complete! Remember to take a moment to appreciate your thoughts.");
        Thread.Sleep(2000);
    }

    // Listing Activity with a countdown
    private static void StartListingActivity()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you make a list of things you want to accomplish.");
        
        // Ask for duration of activity
        Console.Write("Enter the duration for this activity in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        int elapsedTime = 0;

        Console.Clear();
        Console.WriteLine("Start listing your goals now...");
        Thread.Sleep(2000);

        while (elapsedTime < duration)
        {
            Console.Clear();
            Console.WriteLine("How about setting a new goal?");
            string goal = Console.ReadLine();
            elapsedTime += 5; // Assuming each input takes 5 seconds on average
            DisplayProgress(elapsedTime, duration);
        }

        Console.Clear();
        Console.WriteLine("Listing complete! Great job setting your goals!");
        Thread.Sleep(2000);
    }

    // Displays progress bar
    private static void DisplayProgress(int elapsedTime, int totalTime)
    {
        int progress = (int)((double)elapsedTime / totalTime * 100);
        Console.WriteLine($"\nProgress: {progress}%");
        Console.WriteLine(new string('#', progress / 10)); // Simple progress bar
    }
}
