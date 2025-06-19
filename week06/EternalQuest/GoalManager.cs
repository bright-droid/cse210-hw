using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;


    public GoalManager()
    {
        _goals = [];

        _score = 0;
    }


    private int GetScore()
    {
        return _score;
    }

    public void SetScore(int value)
    {
        _score = value;
    }


    public void Start()
    {
        int userChoice = 0;

        while (userChoice != 7)
        {
            DisplayPlayerInfo();


            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Create New Goal\n\t2. List Goals\n\t3. Save Goals\n\t4. Load Goals\n\t5. Record Event\n\t6. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    CreateGoal();
                    break;

                case 2:
                    ListGoalDetails();
                    break;

                case 3:
                    SaveGoals();
                    break;

                case 4:
                    LoadGoals();
                    break;

                case 5:
                    RecordEvent();
                    break;

                case 6:
                    break;

                default:
                    Console.WriteLine("Invalid choice! Select between 1 - 6");
                    break;
            }
        }

        Console.WriteLine("You quit the Eternal Quest program! Goodluck!\n");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {GetScore()} points.\n");
    }

    public void ListGoalNames()
    {
        int i = 0;
        Console.WriteLine("The goals are:");
        foreach (Goal goal in _goals)
        {
            i++;
            Console.WriteLine($"{i}. {goal.GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        int i = 0;

        if (_goals.Count > 0)
        {
            foreach (Goal goal in _goals)
            {
                i++;
                Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            }
        }
        else
        {
            Console.WriteLine("No goals found in your list!");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("\t1. Simple Goal\n\t2. Eternal Goal\n\t3. CheckList Goal");

        Console.Write("What type of goal would you like to create? ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoints);
                _goals.Add(simpleGoal);
                break;

            case 2:
                EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
                _goals.Add(eternalGoal);
                break;

            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                ChecklistGoal checkListGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, target, bonus);
                _goals.Add(checkListGoal);
                break;

            default:
                Console.WriteLine("Invalid choice! Select between 1 -3");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found! Please create goals to record an event.");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames();

        Console.Write("> ");
        int choice = int.Parse(Console.ReadLine());

        int index = choice - 1;
        Goal completedGoal = _goals[index];

        if (completedGoal.IsComplete())
        {
            Console.WriteLine("This goal is already completed!");
            return;
        }

        if (completedGoal is ChecklistGoal)
        {
            ChecklistGoal checkListGoal = (ChecklistGoal)completedGoal;

            completedGoal.RecordEvent();

            if (checkListGoal.IsComplete())
            {
                SetScore(GetScore() + checkListGoal.GetPoints() + checkListGoal.GetBonus());

                Console.WriteLine($"Wow! You stayed consistent and earned {checkListGoal.GetBonus()} bonus points.");
            }
            else
            {
                SetScore(GetScore() + completedGoal.GetPoints());

                Console.WriteLine($"Congratulations! You have earned {completedGoal.GetPoints()} points.");
            }
        }
        else if (completedGoal is EternalGoal || completedGoal is SimpleGoal)
        {
            completedGoal.RecordEvent();
            SetScore(GetScore() + completedGoal.GetPoints());
            Console.WriteLine($"Congratulations! You have earned {completedGoal.GetPoints()} points.");
        }
        else
        {
            Console.WriteLine("Something went wrong! Please try again.");
        }
    }

    public void SaveGoals()
    {
        try
        {
            if (_goals.Count > 0)
            {
                Console.Write("What is the filename for the goal file? ");
                string filename = Console.ReadLine();

                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    outputFile.WriteLine($"{GetScore()}");

                    foreach (Goal goal in _goals)
                    {
                        outputFile.WriteLine($"{goal.GetStringRepresentation()}");
                    }
                }
                Console.WriteLine($"Goals saved to {filename}");
            }
            else
            {
                Console.WriteLine("No goals found! Please create goals to save.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("Error: File is empty");
            return;
        }

        _score = int.Parse(lines[0]);

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string[] parts = line.Split(":");

            string goalType = parts[0];
            string details = parts[1];

            string[] goalDetails = details.Split(",");

            string name = goalDetails[0];
            string description = goalDetails[1];
            int points = int.Parse(goalDetails[2]);

            if (goalType == "SimpleGoal")
            {
                bool completedStatus = bool.Parse(goalDetails[3]);

                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                if (completedStatus)
                {
                    simpleGoal.SetIsComplete();
                }
                _goals.Add(simpleGoal);
            }
            else if (goalType == "EternalGoal")
            {
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
            }
            else
            {
                int bonus = int.Parse(goalDetails[3]);
                int target = int.Parse(goalDetails[4]);
                int amountCompleted = int.Parse(goalDetails[5]);

                ChecklistGoal checkListGoal = new ChecklistGoal(name, description, points, target, bonus);

                for (int j = 0; j < amountCompleted; j++)
                {
                    checkListGoal.SetAmountCompleted();
                }

                if (amountCompleted == target)
                {
                    checkListGoal.IsComplete();
                }

                _goals.Add(checkListGoal);
            }

        }

        Console.WriteLine("Goals loaded successfully!");
    }

}