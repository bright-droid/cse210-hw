public class Swimming : Activity
{
    private int _numberOfLaps;


    public Swimming(DateTime date, int duration, int numberOfLaps) : base(date, duration)
    {
        _numberOfLaps = numberOfLaps;
    }


    private int GetNumberOfLaps()
    {
        return _numberOfLaps;
    }


    public override double GetDistance()
    {
        double distance = GetNumberOfLaps() * 50 / 1000;
        return Math.Round(distance, 2);
    }

    public override double GetSpeed()
    {
        double speed = GetDistance() / base.GetDuration() * 60;
        return Math.Round(speed, 2);
    }

    public override double GetPace()
    {
        double pace = base.GetDuration() / GetDistance();
        return Math.Round(pace, 2);
    }

    public override string GetActivityName()
    {
        return "Swimming";
    }
}