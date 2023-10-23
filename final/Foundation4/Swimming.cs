class Swimming : Activity
{
    private int _laps;
    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public int GetLaps()
    {
        return _laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000; // Distance in kilometers
    }
    public override double GetSpeed()
    {
        if (GetMinutes() == 0)
        {
            return 0;
        }
        return (GetDistance() / GetMinutes()) * 60; // Speed in kph
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
        return $"{base.GetSummary()} - Laps: {_laps}, Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} km/h, Pace: {GetPace():F2} min/km";
    }
}