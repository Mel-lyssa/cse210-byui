public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    // To show creativity I add queues to keep track of used prompts and questions and ensures that they are not repeated until all have been used at least once in that session.
    private Queue<string> _usedPrompts;
    private Queue<string> _usedQuestions;
    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration = 50;
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        // Showing Creativity
        _usedPrompts = new Queue<string>();
        _usedQuestions = new Queue<string>();
    }

    public new void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
    }
    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Consider the following prompt:\n");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"    --- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.\n");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as thay related to this experience.");
        Console.WriteLine("You may begin in:");
        ShowCountDown(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
    {
        foreach (string question in GetRandomQuestions())
        {
            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.WriteLine($"\n> {question}");
            ShowSpinner(10);

            TimeSpan remainingTime = endTime - DateTime.Now;

            if (remainingTime.TotalSeconds < 10)
            {
                break;
            }
        }

        // Showing creativity: Ensure that all prompts/questions have been used before repeating.
        if (_usedPrompts.Count == _prompts.Count)
            {
                _usedPrompts.Clear();
            }

            if (_usedQuestions.Count == _questions.Count)
            {
                _usedQuestions.Clear();
            }

            if ((DateTime.Now - startTime).TotalSeconds > 59)
            {
                Thread.Sleep(1000);
            }
    }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        // Showing creativity: All prompts have been used
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear();
        }

        Random random = new Random();
        int index;
        do
        {
            index = random.Next(_prompts.Count);
        }
        while (_usedPrompts.Contains(_prompts[index]));

        _usedPrompts.Enqueue(_prompts[index]);
        return _prompts[index];
    }

    private Random random = new Random(); // Showing creativity: Create a single Random instance.

    private List<string> GetRandomQuestions()
    {
        // Showing creativity: All questions have been used
        if (_usedQuestions.Count == _questions.Count)
        {
            _usedQuestions.Clear();
        }

        int questionCount = random.Next(1, _questions.Count + 1);
        List<string> randomQuestions = new List<string>();

        while (randomQuestions.Count < questionCount)
        {
            int index;
            do
            {
                index = random.Next(_questions.Count);
            }
            while (_usedQuestions.Contains(_questions[index]));

            _usedQuestions.Enqueue(_questions[index]);
            randomQuestions.Add(_questions[index]);
        }

        return randomQuestions;
    }

    public void DisplayPrompt()
    {

    }
    public void DisplayQuestions()
    {

    }
}