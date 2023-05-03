using System.Net.Mime;

namespace Space_Message_Proxy;

public class Message

{
    public string Text { get; private set; }
    public Message(string text)
    {
        Text = text;
    }
   
}