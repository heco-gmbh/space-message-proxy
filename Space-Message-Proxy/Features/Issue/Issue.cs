namespace Space_Message_Proxy;

public class Issue
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public Principal CreatedBy { get; set; }

    public Issue(IssueDto dto)
    {
        Title = dto.Title;
        Description = dto.Description;
        CreatedBy = new Principal(dto.CreatedBy);
    }
}