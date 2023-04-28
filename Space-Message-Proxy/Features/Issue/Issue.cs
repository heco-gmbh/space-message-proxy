namespace Space_Message_Proxy;

public class Issue
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public Principal CreatedBy { get; set; }
    
    public Channel Channel { get; set; }

    public int Number {get; set; }

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