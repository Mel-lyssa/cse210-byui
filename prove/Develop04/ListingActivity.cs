public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _itemsList;
    private int _count; 
    
    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a";
        _duration = 50;
        _itemsList = new List<string>();
        
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public new void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
    }
    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses you can to the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("You may begin in...");
        ShowCountDown(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            _itemsList.Add(item);
            _count++;
        }

        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }

    public List<string> GetListFromUser()
    {
        return _itemsList;
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}