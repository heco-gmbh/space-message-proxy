namespace Space_Message_Proxy.Document;

public class DocumentCreatedMeta
{
    public Principal Principal { get; private set; }
    public DocumentCreatedMeta(DocumentCreatedMetaDto dto)
    {
        Principal = new Principal(dto.Principal);
    }
    
   
}