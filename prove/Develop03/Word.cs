public class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor initializes the word's text and sets it to not hidden
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hide the word (set the hidden state to true)
    public void Hide()
    {
        _isHidden = true;
    }

    // Reveal the word (set the hidden state to false)
    public void Reveal()
    {
        _isHidden = false;
    }

    // Check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Get the display text: either the word or underscores
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}
