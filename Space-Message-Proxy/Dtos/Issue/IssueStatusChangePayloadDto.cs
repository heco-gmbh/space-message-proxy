using Space_Message_Proxy.Dtos;

namespace Space_Message_Proxy;

public class IssueStatusChangePayloadDto
{
   
    public IssueDto Issue { get; set; }
    public IssueStatusDeltaDto Status { get; set; }
}