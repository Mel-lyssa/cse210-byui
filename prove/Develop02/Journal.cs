public class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }
    public List<Entry> Entries
{
    get { return _entries; }
}


    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public static void SaveToFile(List<Entry> _entries, string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName, true))
        {
            foreach (var entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}|{entry._moodEmotion}");
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                if (parts.Length == 4)
                {
                    Entry loadedEntry = new Entry(parts[0], parts[1], parts[2], parts[3]);
                    _entries.Add(loadedEntry);
                }
                Console.WriteLine(line);
            }
            Console.WriteLine("Journal loaded from file.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}