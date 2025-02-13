using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    // Constructor that takes reference and the scripture text
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(static word => new Word(word)).ToList();
        _random = new Random();
    }

    // Hide a specified number of random words
    public void HideRandomWords(int numberToHide)
    {
        int wordsHidden = 0;
        while (wordsHidden < numberToHide && !IsCompletelyHidden())
        {
            // Get random word that isn't already hidden
            List<Word> visibleWords = _words.Where(static w => !w.IsHidden()).ToList();
            if (visibleWords.Count == 0) break;

            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            wordsHidden++;
        }
    }

    // Show a hint by revealing a random hidden word
    public void ShowHint()
    {
        List<Word> hiddenWords = _words.Where(static w => w.IsHidden()).ToList();
        if (hiddenWords.Count > 0)
        {
            int index = _random.Next(hiddenWords.Count);
            hiddenWords[index].Reveal();
            Console.WriteLine("Hint: A word has been revealed!");
        }
        else
        {
            Console.WriteLine("No hidden words left to reveal.");
        }
    }

    // Get the display text for the entire scripture: reference + words
    public string GetDisplayText()
    {
        string reference = _reference.GetDisplayText();
        string words = string.Join(" ", _words.Select(static w => w.GetDisplayText()));
        return $"{reference}\n{words}";
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(static w => w.IsHidden());
    }
}
