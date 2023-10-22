using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Introduction to C#", "John Harper", 1200);
        video1.AddComment("Alex Lucio", "Great video!");
        video1.AddComment("Thomaz Cesar", "Very informative.");
        video1.AddComment("Sophia Rojas", "That's what I was waiting for!");

        Video video2 = new Video("Web Development Basics", "Jane Metcalf", 720);
        video2.AddComment("Lucy Ramos", "Thanks for the tutorial!");
        video2.AddComment("Henry Moore", "Thanks Jane!");
        video2.AddComment("Tage Reck", "I love your videos");
        video2.AddComment("Sam Westenskow", "Thanks for the video, very informative!");

        Video video3 = new Video("OOP in C# basics", "Benjamin Bird", 840);
        video3.AddComment("Joe Peterson", "Beautifully explained. Thanks! Game developer here trying to make my code better.");
        video3.AddComment("Mike Thompson", "Fantastic, well explained.");
        video3.AddComment("Monica Fieldman", "how can I get the codes used in the tutorial?");

        List<Video> videos = new List<Video> { video1, video2, video3};

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}