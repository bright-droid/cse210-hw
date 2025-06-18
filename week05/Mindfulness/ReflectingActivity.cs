using System.Diagnostics;
public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _remainingQuestions;


    public ReflectingActivity()
    {
        base.SetName("Reflecting");
        base.SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        _prompts = [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ];
        _questions = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ];
        _remainingQuestions = new List<string>(_questions);
    }


    public void Run()
    {
        int duration = base.GetDuration();

        Console.WriteLine("\n Now ponder on each of the following questions as related to your experience.");
        Console.Write($"You may begin in: ");
        base.ShowCountDown(4);

        Console.Clear();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < duration)
        {  
            DisplayQuestions();
        }

        stopwatch.Stop();

    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);

        string prompt = _prompts[index];
        return prompt;
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(0, _remainingQuestions.Count);

        string question = _remainingQuestions[index];

        _remainingQuestions.RemoveAt(index);

        if (_remainingQuestions.Count == 0)
        {
            _remainingQuestions = new List<string>(_questions);
        }

        return question;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("\n Consider the following prompt:\n");
        Console.WriteLine($" --- {GetRandomPrompt()} ---");

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    public void DisplayQuestions()
    {
        Console.Write($"> {GetRandomQuestion()} ");
        base.ShowSpinner(7);
        Console.WriteLine();
    }
}