public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What were the highlights of the day?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What did I learn today?",
        "What am I grateful for today?",
        "What did I eat today, and how did it make me feel?",
        "What was the most unexpected thing that happened today?",
        "What was the weather like today, and did it affect my activities?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}