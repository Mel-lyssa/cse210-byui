using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Xml;

public class Video
{
    public string _title;
    public string _author;
    public int _length; // seconds
    public List<Comment> _comments;

    public int GetNumComments()
    {
        return _length;
    }

    public void AddComment(Comment comment)
    {
        
    }
}