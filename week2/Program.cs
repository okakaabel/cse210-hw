using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a journal instance
        Journal myJournal = new Journal();

        bool exitProgram = false;
        
        while (!exitProgram)
        {
            // Display a simple menu for the user to choose an option
            Console.Clear();
            Console.WriteLine("Welcome to your Journal!");
            Console.WriteLine("1. Add a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Search for an entry");
            Console.WriteLine("6. Exit");
            Console.Write("\nPlease choose an option (1-6): ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    myJournal.AddEntry();
                    break;
                
                case "2":
                    myJournal.DisplayEntries();
                    break;
                
                case "3":
                    myJournal.SaveToFile();
                    break;
                
                case "4":
                    myJournal.LoadFromFile();
                    break;
                
                case "5":
                    Console.Write("\nEnter the prompt you want to search for: ");
                    string searchTerm = Console.ReadLine();
                    myJournal.SearchEntries(searchTerm);
                    break;
                
                case "6":
                    exitProgram = true;
                    break;
                
                default:
                    Console.WriteLine("\nInvalid choice, please try again.");
                    break;
            }
            
            if (!exitProgram)
            {
                // Pause the program to let the user read the output before the next action
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Thank you for using the journal application!");
    }
}
