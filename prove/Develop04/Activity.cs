public class Activity
{
    protected string _name = "";
    protected string _description = "";
    protected int _duration;

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);

        Console.Write("\nHow long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());
        _duration = duration;

        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!\n");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>
        {
            "|", "/", "-", "\\"
        };

        int animationIndex = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[animationIndex]);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            animationIndex = (animationIndex + 1) % animationStrings.Count;
        }
    }

    public void ShowCountDown(int second)
    {
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}