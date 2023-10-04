public class MathAssignment : Assignment
{
    private string _textbookSection = "";
    private string _problems = "";

     public string GetTextbookSection()
    {
        return _textbookSection;
    }
    public void SetTextbookSection(string textbookSection)
    {
        _textbookSection = textbookSection;
    }

    public string GetProblems()
    {
        return _problems;
    }
    public void SetProblems(string problems)
    {
        _problems = problems;
    }
    public string GetHomeworkList()
    {
        return $"\n{_studentName} - {_topic}\nSection {_textbookSection} Problems {_problems}";
    }
}