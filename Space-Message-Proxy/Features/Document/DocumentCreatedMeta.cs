namespace Space_Message_Proxy.Document;

public class DocumentCreatedMeta
{
    public DocumentCreatedMeta(DocumentCreatedMetaDto dto)
    {
        Principal = new Principal(dto.Principal);
    }
    
    public Principal Principal { get; set; }
}