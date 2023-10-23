class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        if (GetMinutes() == 0)
        {
            return 0;
        }
        return (GetDistance() / GetMinutes()) * 60; // Speed in kph
    }
    public override double GetDistance()
    {
        return (_speed / 60) * GetMinutes(); // Distance in miles
    }
    public override double GetPace()
    {
        if (GetDistance() == 0)
        {
            return 0;
        }
        return GetMinutes() / GetDistance(); // Pace in min/km
    }

    public new string GetSummary()
    {
        return $"{base.GetSummary()} - Speed: {_speed:F2} mph, Distance: {GetDistance():F2} miles, Pace: {GetPace():F2} min/mile";
    }
}