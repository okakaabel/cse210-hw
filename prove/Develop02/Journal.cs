using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries;   // List of journal entries
    private List<string> _prompts;   // List of journal prompts
    private Random _random;         // Random object to select a prompt

    // Constructor initializes lists and predefined prompts.
    public Journal()
    {
        _entries = new List<Entry>();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was the most challenging thing I faced today?",
            "What am I most grateful for today?",
            "What did I learn today?"
        };
        _random = new Random();
    }

    // Add a new entry to the journal.
    public void AddEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nPrompt: " + prompt);
        Console.Write("> ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Include time for better detail
        
        _entries.Add(new Entry(prompt, response, date));
        Console.WriteLine("\nEntry added successfully!");
    }

    // Display all journal entries.
    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.");
            return;
        }

        Console.WriteLine("\nJournal Entries:");
        Console.WriteLine("----------------");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    // Save all journal entries to a file.
    public void SaveToFile()
    {
        Console.Write("\nEnter filename to save: ");
        string filename = Console.ReadLine();

        try
        {
            // Ensure the file is backed up before overwriting
            BackupFile(filename);

            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToFileString());
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    // Backup the file before saving new entries.
    private void BackupFile(string filename)
    {
        if (File.Exists(filename))
        {
            string backupFilename = filename.Replace(".txt", "_backup.txt");
            File.Copy(filename, backupFilename, overwrite: true);
            Console.WriteLine("Backup created: " + backupFilename);
        }
    }

    // Load journal entries from a file.
    public void LoadFromFile()
    {
        Console.Write("\nEnter filename to load: ");
        string filename = Console.ReadLine();

        try
        {
            _entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _entries.Add(Entry.FromFileString(line));
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please check the filename.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    // Get a random prompt from the list.
    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Search for journal entries by prompt or response.
    public void SearchEntries(string searchTerm)
    {
        var foundEntries = _entries.Where(entry => entry.Prompt.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                                     entry.Response.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundEntries.Count > 0)
        {
            Console.WriteLine("\nSearch Results:");
            Console.WriteLine("----------------");
            foreach (Entry entry in foundEntries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
        else
        {
            Console.WriteLine("No entries found matching your search term.");
        }
    }
}
