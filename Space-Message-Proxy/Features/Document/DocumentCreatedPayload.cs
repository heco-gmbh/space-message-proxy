namespace Space_Message_Proxy.Document;

public class DocumentCreatedPayload
{
    public string Document { get; set; }
    public DocumentCreatedMeta Meta { get; set; }

    public DocumentCreatedPayload(DocumentCreatedPayloadDto dto)
    {
        Document = dto.Document;
        Meta = new DocumentCreatedMeta(dto.Meta);
    }
}