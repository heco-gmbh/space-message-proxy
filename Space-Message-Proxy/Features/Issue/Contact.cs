namespace Space_Message_Proxy;

public class Contact 
{
    public Ext Ext { get; private set; }
    public string DefaultName { get; private set; }
    public Contact(ContactDto dto)
    {
        Ext = new Ext(dto.Ext);
        DefaultName = dto.DefaultName;
    }
}