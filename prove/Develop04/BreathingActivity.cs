public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _duration = 50;
    }

    public new void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();;
        Thread.Sleep(3 * 1000);
    }

    public void Run()
{
    DisplayStartingMessage();

    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(_duration);

    while (DateTime.Now < endTime)
    {
        if (DateTime.Now >= endTime)
        {
            break;
        }

        Console.WriteLine("\nBreathe in...");
        ShowCountDown(3);

        if (DateTime.Now >= endTime)
        {
            break;
        }

        Console.WriteLine("\nNow breathe out...");
        ShowCountDown(3);

        TimeSpan remainingTime = endTime - DateTime.Now;

        if (remainingTime.TotalSeconds < 6)
        {
            break;
        }
    }

    DisplayEndingMessage();
}

}