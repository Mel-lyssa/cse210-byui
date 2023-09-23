using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Please select one of the following choises");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {randomPrompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    Console.WriteLine("What was your mood or emotion at that moment?"); // Added to show creativity
                    string moodEmotion = Console.ReadLine();
                    DateTime theCurrentTime = DateTime.Now;
                    string dateText = theCurrentTime.ToString("dd/MM/yyyy");
                    Entry newEntry = new Entry(dateText, randomPrompt, response, moodEmotion); // Added to show creativity
                    journal.AddEntry(newEntry);
                    break;

                case 2:
                    journal.DisplayAll();
                    break;

                case 3:
                    Console.Write("What is the filename to save? ");
                    string saveFileName = Console.ReadLine();
                    Journal.SaveToFile(journal.Entries, saveFileName);
                    break;

                case 4:
                    Console.Write("What is the filename to load? ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}