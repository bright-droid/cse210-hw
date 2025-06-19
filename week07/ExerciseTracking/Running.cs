public class Running : Activity
{
    private double _distance;


    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }


    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed(){
        return Math.Round(GetDistance() / base.GetDuration() * 60, 2);
    }

    public override double GetPace(){
        return Math.Round(base.GetDuration() / GetDistance(), 2);
    }

    public override string GetActivityName(){
        return "Running";
    }
}