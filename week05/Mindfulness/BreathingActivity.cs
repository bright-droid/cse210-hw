using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        base.SetName("Breathing");
        base.SetDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    public void Run()
    {
        Console.WriteLine($"\n\n");

        int duration = base.GetDuration();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < duration)
        {  
            Console.Write("Breathe in...");
            base.ShowCountDown(4);
            Console.WriteLine();
            Console.Write("Now breathe out...");
            base.ShowCountDown(6);
            Console.WriteLine("\n");
        }

        stopwatch.Stop();
    }
}