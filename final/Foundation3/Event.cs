using System.Net.Sockets;

class Event
{
    protected string _title;
    protected string _description;
    DateTime _date;
    TimeSpan _time;
    Address _address;

    public string GetStandardDetails();
    public string GetFullDetails();
    public string GetShortDescription();
}