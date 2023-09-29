using System;

/*
To show creativity, I added a list to insert new scriptures, and they are randomly chosen. 
When the program ends, I included a question for the user to answer whether they would like to memorize another scripture. 
If they do, the program starts over with a new scripture; if not, the program terminates.
*/
class Program
{
    static void Main()
    {
        while (true) // Added to show criativity
        {
            List<Scripture> scriptures = new List<Scripture>(); // Added to show criativity
            scriptures.Add(CreateScripture("Ether", 12, 27, "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them."));
            scriptures.Add(CreateScripture("Mosiah", 5, 13, "For how knoweth a man the master whom he has not served, and who is a stranger unto him, and is far from the thoughts and intents of his heart?"));
            scriptures.Add(CreateScripture("Jacob", 4, 10, "Wherefore, brethren, seek not to counsel the Lord, but to take counsel from his hand. For behold, ye yourselves know that he counseleth in wisdom, and in justice, and in great mercy, over all his works."));
            scriptures.Add(CreateScripture("3 Nephi", 13, 33, "But seek ye first the kingdom of God and his righteousness, and all these things shall be added unto you."));

            Random random = new Random(); // Added to show criativity
            int randomIndex = random.Next(0, scriptures.Count);
            Scripture selectedScripture = scriptures[randomIndex];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue or type 'quit' to finish: ");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "quit" || selectedScripture.IsCompletelyHidden())
                {
                    break;
                }

                selectedScripture.HideRandomWords(3);
            }

            // Added to show criativity
            Console.WriteLine();
            Console.WriteLine("Do you want to memorize another scripture? (yes/no)");
            string response = Console.ReadLine().ToLower();
            if (response != "yes")
            {
                break;
            }
        }

        Console.WriteLine();
    }
    static Scripture CreateScripture(string book, int chapter, int verse, string text)
    {
        Reference reference = new Reference(book, chapter, verse);
        return new Scripture(reference, text);
    }
}