namespace Space_Message_Proxy;

public class Channel
{
    public Contact Contact { get; private set; }
    public Channel(ChannelDto dto)
    {
        Contact = new Contact(dto.Contact);
    }

    

}