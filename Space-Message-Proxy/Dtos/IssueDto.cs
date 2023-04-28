using System.Threading.Channels;

namespace Space_Message_Proxy;

public class IssueDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public PrincipalDto CreatedBy { get; set; }
    public ChannelDto Channel { get; set; }
    public int Number { get; set; }
}