public abstract class Activity
{
    private DateTime _date;
    private int _duration;

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }


    protected DateTime GetDate()
    {
        return _date;
    }

    protected int GetDuration()
    {
        return _duration;
    }


    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public abstract string GetActivityName(); 
    
    public void GetSummary()
    {
        string year = GetDate().ToString("yyyy");
        string month = GetDate().ToString("MMM");
        string day = GetDate().ToString("dd");

        Console.WriteLine($"{day} {month} {year} {GetActivityName()} ({GetDuration()} min): Distance {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km\n");
    }
}