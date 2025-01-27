// Represents a journal entry with a prompt, response, and date.
public class Entry
{
    public string Prompt { get; set; }  // The prompt question for the journal entry
    public string Response { get; set; }  // The user's response to the prompt
    public string Date { get; set; }  // The date the entry was created

    // Constructor that initializes the entry with a prompt, response, and date.
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Override the ToString() method to provide a custom string representation of the entry.
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\n{Response}\n";
    }

    // Method to convert entry to a string format that can be saved to a file.
    public string ToFileString(string separator = "~|~")
    {
        return $"{Date}{separator}{Prompt}{separator}{Response}";
    }

    // Static method to create an Entry object from a file string.
    public static Entry FromFileString(string fileString, string separator = "~|~")
    {
        string[] parts = fileString.Split(separator);
        
        // Ensure the string format is correct before creating an entry
        if (parts.Length != 3)
        {
            throw new FormatException("Invalid file string format");
        }
        
        // Return a new Entry object created from the file string
        return new Entry(parts[1], parts[2], parts[0]);
    }
}
