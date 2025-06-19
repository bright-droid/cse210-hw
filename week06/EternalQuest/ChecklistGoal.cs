public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }


    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetTarget()
    {
        return _target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public void SetAmountCompleted()
    {
        _amountCompleted +=1;
    }


    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            SetAmountCompleted();
        }
        else
        {
            IsComplete();
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    public override string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[X] {base.GetShortName()} ({base.GetDescription()}) -- Currently completed: {GetAmountCompleted()}/{GetTarget()} ";
        }
        else
        {
            return $"[ ] {base.GetShortName()} ({base.GetDescription()}) -- Currently completed: {GetAmountCompleted()}/{GetTarget()} ";           
        }
    }

    public override string GetStringRepresentation()
    {
        return $"CheckListGoal:{base.GetShortName()},{base.GetDescription()},{base.GetPoints()},{GetBonus()},{GetTarget()},{GetAmountCompleted()}";
    }
}