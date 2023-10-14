public class ChecklistGoal : Goal
{
    public int _amountCompleted;
    public int _target;
    public int _bonus;
    public int AmountCompleted { get; private set; }
    

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base (shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public void SetAmountCompleted(int amountCompleted)
    {
        AmountCompleted = amountCompleted;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        if (_amountCompleted >= _target)
        {
            return "[X]";
        }
        else
        {
            return "[ ]";
        }
    }

}