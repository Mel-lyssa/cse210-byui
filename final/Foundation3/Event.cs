using System.Net.Sockets;

class Event
{
    private string _title;
    private string _description;
    private DateTime _date;
    private TimeSpan _time;
    private Address _address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public string GetTitle()
    {
        return _title;
    }
    public string GetDescription()
    {
        return _description;
    }
    public DateTime GetDate()
    {
        return _date;
    }
    public TimeSpan GetTime()
    {
        return _time;
    }
    public Address GetAddress()
    {
        return _address;
    }
    
    public string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date:d}\nTime: {_time}";
    }

    public string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nAddress: {_address.GetFullAddress()}";
    }
}