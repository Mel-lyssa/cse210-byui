using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        Console.WriteLine("What is the magic number?");
        Console.WriteLine("What is your guess?");
        string guess = Console.ReadLine();
        int guessNumber = int.Parse(guess);

        while (true)
        {
            if (guessNumber > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guessNumber < number)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                break;
            }

            Console.WriteLine("What is your guess?");
            guess = Console.ReadLine();
            guessNumber = int.Parse(guess);
        }
    }
}