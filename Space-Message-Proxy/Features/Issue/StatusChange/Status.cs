using Space_Message_Proxy.Dtos;

namespace Space_Message_Proxy;

public class Status
{
    public string Name { get; private set; }

    public Status(StatusDto dto)
    {
        Name = dto.Name;
    }
    
}