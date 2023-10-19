class Activity
{
    DateTime Date;
    private int _minutes;

    private virtual double GetDistance();
    private virtual double GetSpeed();
    private virtual double GetPace();
    private string GetSummary();
}