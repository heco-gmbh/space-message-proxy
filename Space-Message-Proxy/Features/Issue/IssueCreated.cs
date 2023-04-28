namespace Space_Message_Proxy;

public class IssueCreated
{
    public IssueCreatedPayload Payload { get; set; }
    public IssueCreated(IssueCreatedDto dto)
    {
        Payload = new IssueCreatedPayload(dto.Payload);
    }

    
    public Message toMessage(string hostname)
    {
        return new Message()
        {
            Text = $"\n*{Payload.Issue.CreatedBy.Name} hat ein Issue erstellt:* :rocket: \n\n *{Payload.Issue.Title}* \n _{Payload.Issue.Description?? "Keine Beschreibung"}_ \n {Payload.Issue.GetLink(hostname)}"
        };
    }
    
}