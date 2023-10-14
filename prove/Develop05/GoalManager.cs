public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1; //Showing creativity: Initialize the level to 1

    public GoalManager()
    {

    }
    public void Start()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Create New Goal");
        Console.WriteLine(" 2. List Goals");
        Console.WriteLine(" 3. Save Goals");
        Console.WriteLine(" 4. Load Goals");
        Console.WriteLine(" 5. Record Event");
        Console.WriteLine(" 6. Quit");
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }
    //Showing creativity: Display Message
    public void DisplayPlayerLevel()
    {
        Console.WriteLine($"Your current level is level {_level}\n");
    }
    public void ListGoalNames()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe Goals are:");
        int goalNumber = 1;
        foreach (Goal goal in _goals)
        {
            string goalStatus = goal.GetStringRepresentation();
            Console.WriteLine($"{goalNumber}. {goalStatus} {goal.GetDetailsString()}");
            Console.WriteLine();
            goalNumber++;
        }
    }


    public void CreateGoal(string goalType, string shortName, string description, int points, int target = 0, int bonusPoints = 0)
    {
        Goal newGoal = null;

        switch (goalType)
        {
            case "1":
                newGoal = new SimpleGoal(shortName, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(shortName, description, points);
                break;
            case "3":
                newGoal = new ChecklistGoal(shortName, description, points, target, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine($"Goal '{shortName}' created successfully!");
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = _goals.Find(g => g._shortName == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            _score += goal._points;
            Console.WriteLine($"Event recorded for '{goalName}'! You gained {goal._points} points.");
            // Showing creativity: Check for leveling up every 1000 points
            int previousLevel = _level;
            _level = (_score / 1000) + 1; // Calculate the new level

            if (_level > previousLevel)
            {
                Console.WriteLine($"Congratulations! You've leveled up to level {_level}!");
            }
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' not found.");
        }
    }
    public void SaveGoals()
    {
        Console.Write("Enter the file name to save your goals: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                foreach (Goal goal in _goals)
                {
                    if (goal is ChecklistGoal checklistGoal)
                    {
                        string goalInfo = $"{goal._shortName}|{goal._description}|{goal._points}|{checklistGoal._target}|{checklistGoal._amountCompleted}|{checklistGoal.IsComplete()}";
                        writer.WriteLine(goalInfo);
                    }
                    else
                    {
                        string goalInfo = $"{goal._shortName}|{goal._description}|{goal._points}|{goal.IsComplete()}";
                        writer.WriteLine(goalInfo);
                    }
                }
            }

            Console.WriteLine($"Goals and score saved successfully to {fileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load goals from: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                Console.WriteLine("\nLoaded Goals:");

                int goalNumber = 1;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] goalInfo = line.Split('|');

                    if (goalInfo.Length >= 3)
                    {
                        string shortName = goalInfo[0];
                        string description = goalInfo[1];
                        int points = int.Parse(goalInfo[2]);
                        bool isComplete = false;
                        

                        if (goalInfo.Length == 4 && bool.TryParse(goalInfo[3], out isComplete))
                        {
                            // If the 4th element is a boolean indicating completion status
                            var loadedGoal = new SimpleGoal(shortName, description, points);
                            if (isComplete)
                            {
                                loadedGoal.RecordEvent();
                                _score += loadedGoal._points;
                            }

                            string goalStatus = loadedGoal.GetStringRepresentation();
                            Console.WriteLine($"{goalNumber}. {goalStatus} {loadedGoal.GetDetailsString()}");
                            Console.WriteLine();
                        }
                        else if (goalInfo.Length == 4 && bool.TryParse(goalInfo[3], out isComplete))
                        {
                            // If the 4th element is a boolean indicating completion status
                            var loadedGoal = new EternalGoal(shortName, description, points);
                            if (isComplete)
                            {
                                loadedGoal.RecordEvent();
                                _score += loadedGoal._points;
                            }

                            string goalStatus = loadedGoal.GetStringRepresentation();
                            Console.WriteLine($"{goalNumber}. {goalStatus} {loadedGoal.GetDetailsString()}");
                            Console.WriteLine();
                        }
                        else if (goalInfo.Length == 6 && bool.TryParse(goalInfo[5], out isComplete))
                        {
                            int target = int.Parse(goalInfo[3]);
                            int amountCompleted = int.Parse(goalInfo[4]);
                            isComplete = bool.Parse(goalInfo[5]);
                            var loadedGoal = new ChecklistGoal(shortName, description, points, target, 0);
                            if (isComplete)
                            {
                                loadedGoal.RecordEvent();
                                _score += loadedGoal._points;
                            }

                            loadedGoal.SetAmountCompleted(amountCompleted); // Set the amount completed

                            string goalStatus = isComplete ? "[X]" : "[ ]"; // Set goalStatus based on completion
                            Console.WriteLine($"{goalNumber}. {goalStatus} {shortName} ({description}) -- Completed {amountCompleted}/{target}");
                            Console.WriteLine();

                        }
                        goalNumber++;
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Make sure the file exists in the specified path.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while loading goals: {e.Message}");
        }
    }
}