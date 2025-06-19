using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = [];

        DateTime today = DateTime.Now;

        Running running = new Running(today, 30, 4.8);

        Cycling cycling = new Cycling(today, 30, 45.13);

        Swimming swimming = new Swimming(today, 30, 20);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            activity.GetSummary();
        }

    }
}