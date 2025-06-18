using System.Diagnostics;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _items;


    public ListingActivity()
    {
        base.SetName("Listing");
        base.SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        _count = 0;
        _prompts = [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];
        _items = [];
    }

    public int GetCount()
    {
        return _count;
    }

    private void SetCount(int value)
    {
        _count = value;
    }


    public void Run()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        base.ShowCountDown(4);
        Console.WriteLine("");

        int duration = base.GetDuration();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        _items.Clear();

        while (stopwatch.Elapsed.TotalSeconds < duration)
        {
            GetListFromUser();
        }

        SetCount(_items.Count);

        stopwatch.Stop();

        Console.WriteLine($"You listed {GetCount()} items!");
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);

        string prompt = _prompts[index];
        return prompt;        
    }

    public List<string> GetListFromUser()
    {
        Console.Write("> ");
        string listItem = Console.ReadLine();
        _items.Add(listItem);

        return _items;
    }
}