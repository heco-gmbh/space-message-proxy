namespace Space_Message_Proxy;

public class IssueStatusChangePayload
{
    public Issue Issue { get; private set; }
    public IssueStatusDelta Status { get; private set; }

    public IssueStatusChangePayload(IssueStatusChangePayloadDto dto)
    {
        Issue = new Issue(dto.Issue);
        Status = new IssueStatusDelta(dto.Status);
    }
}