using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;


    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }


    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    protected void SetName(string value)
    {
        _name = value;
    }

    protected void SetDescription(string value)
    {
        _description = value;
    }

    protected void SetDuration(int value)
    {
        _duration = value;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.\n{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());
        SetDuration(duration);

        Console.Clear();
        Console.WriteLine("Get ready...");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done!!");
        ShowSpinner(4);
        Console.WriteLine($"\nYou have completed another {GetDuration()} seconds of the {_name} Activity.");
        ShowSpinner(4);
    }

    public void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        List<string> animationStrings = ["|", "/", "-", "\\"];

        int i = 0;

        while (DateTime.Now < endTime)
        {

            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }  
        }
    }

    public void ShowCountDown(int second)
    {
        for (int i = second; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}