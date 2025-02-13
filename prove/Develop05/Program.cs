using System;

public class Program
{
    private static QuestManager mQuestManager = new QuestManager();

    public static void Main()
    {
        bool running = true;
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    mQuestManager.DisplayGoals();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    mQuestManager.DisplayScore();
                    break;
                case "5":
                    SaveProgress();
                    break;
                case "6":
                    LoadProgress();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("\n=== Eternal Quest Menu ===");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Record Event");
        Console.WriteLine("4. Display Score");
        Console.WriteLine("5. Save Progress");
        Console.WriteLine("6. Load Progress");
        Console.WriteLine("7. Quit");
        Console.Write("Select an option: ");
    }

    private static void CreateNewGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal;
        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        mQuestManager.AddGoal(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    private static void RecordEvent()
    {
        mQuestManager.DisplayGoals();
        Console.Write("\nWhich goal did you accomplish? (Enter the number) ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            mQuestManager.RecordEvent(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private static void SaveProgress()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        mQuestManager.SaveToFile(filename);
        Console.WriteLine("Progress saved successfully!");
    }

    private static void LoadProgress()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        mQuestManager.LoadFromFile(filename);
        Console.WriteLine("Progress loaded successfully!");
    }
}
