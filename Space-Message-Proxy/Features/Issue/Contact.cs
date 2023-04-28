namespace Space_Message_Proxy;

public class Contact 
{
    public Ext Ext { get; set; }
    public string DefaultName { get; set; }
    public Contact(ContactDto dto)
    {
        Ext = new Ext(dto.Ext);
        DefaultName = dto.DefaultName;
    }
}