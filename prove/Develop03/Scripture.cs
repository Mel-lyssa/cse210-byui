using System.Text;
using System.Text.RegularExpressions;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private int _hiddenWordCount;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = ExtractWords(text);
        _hiddenWordCount = 0;
        
    }

    public void HideRandomWords(int numberToHide)
    {
        if (_hiddenWordCount >= _words.Count)
        {
            return;
        }

        Random random = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            if (_hiddenWordCount >= _words.Count)
            {
                return;
            }

            int randomIndex;
            do
            {
                randomIndex = random.Next(0, _words.Count);
            } while (_words[randomIndex].IsHidden());

            _words[randomIndex].Hide();
            _hiddenWordCount++;
        }
    }


    public string GetDisplayText()
    {
        StringBuilder displayText = new StringBuilder(_reference.GetDisplayText());
        displayText.Append(" - ");

        foreach (Word word in _words)
        {
            displayText.Append(word.GetDisplayText());
            displayText.Append(" ");
        }
        return displayText.ToString().Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    private List<Word> ExtractWords(string text)
    {
        string[] wordsArray = Regex.Split(text, @"\W+");
        return wordsArray.Where(w => !string.IsNullOrWhiteSpace(w)).Select(w => new Word(w)).ToList();
    }

}
