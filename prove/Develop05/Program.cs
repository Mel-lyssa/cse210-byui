using System;
// To show creativity I added a code that keeps track of the current level based on the player's score. 
//If the score reaches or exceeds 1000 points, the player levels up, and the level information is displayed.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to the Goal Manager!");
        GoalManager goalManager = new GoalManager();
        goalManager.DisplayPlayerInfo();
        goalManager.DisplayPlayerLevel();

        bool exit = false;

        while (!exit)
        {
            goalManager.Start();
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.ListGoalNames();
                    Console.Write("Which type of goal would you like to create? ");
                    string goalType = Console.ReadLine();
                    if (goalType == "3")
                    {
                        Console.Write("What is the name of your goal? ");
                        string shortName = Console.ReadLine();
                        Console.Write("What is a short description of it? ");
                        string description = Console.ReadLine();
                        Console.Write("What is the amount of points associated with this goal? ");
                        int points = int.Parse(Console.ReadLine());
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("What is the bonus points for accomplishing it that many times? ");
                        int bonusPoints = int.Parse(Console.ReadLine());
                        goalManager.CreateGoal(goalType, shortName, description, points, target, bonusPoints);
                    }
                    else
                    {
                        Console.Write("Enter goal name: ");
                        string shortName = Console.ReadLine();
                        Console.Write("Enter goal description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter goal points: ");
                        int points = int.Parse(Console.ReadLine());
                        goalManager.CreateGoal(goalType, shortName, description, points);
                    }
                    break;

                case "2":
                    goalManager.ListGoalDetails();
                    goalManager.DisplayPlayerInfo();
                    goalManager.DisplayPlayerLevel();
                    Console.Write("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                        
                case "3":
                    goalManager.SaveGoals();
                    Console.Write("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                
                case "4":
                    goalManager.LoadGoals();
                    goalManager.DisplayPlayerInfo();
                    goalManager.DisplayPlayerLevel();
                    Console.WriteLine();
                    break;

                case "5":
                    Console.Write("Enter the goal name to record an event: ");
                    string goalName = Console.ReadLine();
                    goalManager.RecordEvent(goalName);
                    break;

                case "6":
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        }
    }
}