public class Cycling : Activity
{
    private double _speed;


    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }


    public override double GetDistance()
    {
        return Math.Round(_speed * base.GetDuration() / 60, 2);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return Math.Round(base.GetDuration() / GetDistance(), 2);
    }

    public override string GetActivityName()
    {
        return "Cycling";
    }
}