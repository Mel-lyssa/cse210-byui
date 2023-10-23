class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }
    public override double GetDistance()
    {
        return _distance;
    }
    public override double GetSpeed()
    {
        if (GetMinutes() == 0)
        {
            return 0;
        }
        return (GetDistance() / GetMinutes()) * 60; // Speed in miles per hour
    }
    public override double GetPace()
    {
        if (GetDistance() == 0)
        {
            return 0;
        }
        return GetMinutes() / GetDistance(); // Pace in minutes per mile
    }

    public new string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {_distance:F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min/mile";
    }
}