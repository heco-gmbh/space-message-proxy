using Space_Message_Proxy.Dtos;

namespace Space_Message_Proxy;

public class IssueStatusDelta
{
    public Status Old { get; private set; }
    public Status New { get; private set; }

    public IssueStatusDelta(IssueStatusDeltaDto dto)
    {
        Old = new Status(dto.Old);
        New = new Status(dto.New);
    }
    
    
}