using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Xml;

public class Video
{
    private string _title;
    private string _author;
    private int _length; // seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public int GetNumComments()
    {
        return _comments.Count;
    }

    public void AddComment(string commenterName, string commentText)
    {
        Comment comment = new Comment(commenterName, commentText);
        _comments.Add(comment);
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length (seconds): {_length}");
        Console.WriteLine($"Number of Comments: {GetNumComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            Console.WriteLine($"- Commenter: {comment._commenterName}, Comment: {comment._text}");
        }
    }
}