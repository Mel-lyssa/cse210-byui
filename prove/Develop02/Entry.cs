public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public string _moodEmotion; // Added to show creativity

    public Entry(string date, string promptText, string entryText, string moodEmotion) // Added to show creativity
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _moodEmotion = moodEmotion;
    }
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine($"Mood/Emotion: {_moodEmotion}\n"); // Added to show creativity
    }
}