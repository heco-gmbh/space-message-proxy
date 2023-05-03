namespace Space_Message_Proxy;

public class IssueStatusChange
{
    public IssueStatusChangePayload Payload { get; private set; }

    public IssueStatusChange(IssueStatusChangeDto dto)
    {
        Payload = new IssueStatusChangePayload(dto.Payload);
    }

    public Message ToMessage(string hostname)
    {
        return new Message($"\n {Payload.Issue.Title} ist im Status *{Payload.Status.New.Name}* :rocket: \n\n {Payload.Issue.GetLink(hostname)}");
    }
}