class Reception : Event
{
    private string _email;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _email = rsvpEmail;
    }

    public string GetRSVP()
    {
        return _email;
    }

    public new string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {_email}";
    }
}