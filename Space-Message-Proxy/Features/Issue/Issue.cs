namespace Space_Message_Proxy;

public class Issue
{
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Principal CreatedBy { get; private set; }
    
    public Channel Channel { get; private set; }

    public int Number {get; private set; }

    public Issue(IssueDto dto)
    {
        Title = dto.Title;
        Description = dto.Description;
        CreatedBy = new Principal(dto.CreatedBy);
        Channel = new Channel(dto.Channel);
        Number = dto.Number;
    }
    
    public string GetLink(string hostname)
    {
        return $"{hostname}/p/{Channel.Contact.Ext.ProjectKey.Key}/issues/{Number}";
    }
}