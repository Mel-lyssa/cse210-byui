class Activity
{
    private DateTime _date;
    protected int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }
    public virtual double GetSpeed()
    {
    if (GetPace() == 0)
    {
        return 0;
    }
    return 60 / GetPace(); // Speed in km/h or mph
}
    public virtual double GetPace()
    {
        if (GetSpeed() == 0)
        {
            return 0;
        }
        return 60 / GetSpeed(); // Pace in minutes per kilometer or mile
    }
    public string GetSummary()
    {
        string activityType = this.GetType().Name;
        return $"{GetDate():dd MMM yyyy} {activityType} ({GetMinutes()} min): Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F1} min per km";
    }
}