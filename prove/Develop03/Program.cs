using System;

class Program
{
    static void Main(string[] args)
    {
        // Sample scripture (you could load this from a file or library)
        Reference reference = new Reference("John", 3, 16);
        string scriptureText = "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life";
        Scripture scripture = new Scripture(reference, scriptureText);

        // Additional example with verse range
        // Reference proverbs = new Reference("Proverbs", 3, 5, 6);
        // string proverbsText = "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths";
        // Scripture proverbsScripture = new Scripture(proverbs, proverbsText);

        string input = "";
        while (input.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            
            input = Console.ReadLine();
            if (input.ToLower() != "quit")
            {
                scripture.HideRandomWords(3); // Hide 3 words at a time
            }
        }
    }
}
