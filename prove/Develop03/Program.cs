using System;

class Program
{
    static void Main(string[] args)
    {
        // Sample scriptures
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life"),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths")
        };

        string input = "";
        foreach (var scripture in scriptures)
        {
            Console.Clear();
            // Display the initial scripture
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, type 'quit' to finish or 'hint' to reveal a word:");
            
            while (input.ToLower() != "quit" && !scripture.IsCompletelyHidden())
            {
                input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }
                else if (input.ToLower() == "hint")
                {
                    scripture.ShowHint(); // Show a hint by revealing one word
                }
                else
                {
                    int wordsToHide = 3;
                    Console.WriteLine($"Hiding {wordsToHide} random words...");
                    scripture.HideRandomWords(wordsToHide); // Hide 3 words at a time
                }

                // Show updated scripture
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            }

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You've hidden all words!");
                Console.WriteLine("Press Enter to continue to the next scripture or type 'quit' to finish.");
            }
        }
    }
}
