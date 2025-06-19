public class SimpleGoal : Goal
{
    private bool _isComplete;


    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public void SetIsComplete()
    {
        _isComplete = true;
    }


    public override void RecordEvent()
    {
        SetIsComplete();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{base.GetShortName()},{base.GetDescription()},{base.GetPoints()},{IsComplete()}";
    }
}