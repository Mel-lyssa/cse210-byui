using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Salt St", "Cityville", "CA", "USA");
        Address address2 = new Address("456 Lake St", "Townsville", "NY", "USA");

        Lecture lectureEvent = new Lecture("Programming Seminar", "Learn about C#", new DateTime(2023, 4, 15), new TimeSpan(14, 30, 0), address1, "John Doe", 100);
        Reception receptionEvent = new Reception("Networking Night", "Meet and Greet", new DateTime(2023, 5, 20), new TimeSpan(18, 0, 0), address2, "rsvp@example.com");
        OutdoorGathering outdoorEvent = new OutdoorGathering("Picnic in the Park", "Family-friendly event", new DateTime(2023, 6, 10), new TimeSpan(12, 0, 0), address1, "Sunny and pleasant weather expected.");

        DisplayEventDetails(lectureEvent);
        DisplayEventDetails(receptionEvent);
        DisplayEventDetails(outdoorEvent);
    }

    static void DisplayEventDetails(Event eventObj)
    {
        Console.WriteLine("----------------------");
        Console.WriteLine();
        Console.WriteLine(eventObj.GetFullDetails());
        Console.WriteLine();
    }
}