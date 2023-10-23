class OutdoorGathering : Event
{
    private string _weatherStatement;
    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        _weatherStatement = weatherStatement;
    }

    public string GetWeatherStatement()
    {
        return _weatherStatement;
    }

    public new string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather: {_weatherStatement}";
    }
}