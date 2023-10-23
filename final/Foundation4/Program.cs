using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2023, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2023, 11, 4), 60, 20.5),
            new Swimming(new DateTime(2023, 11, 5), 40, 50)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}