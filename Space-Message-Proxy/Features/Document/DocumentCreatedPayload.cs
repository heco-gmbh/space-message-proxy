namespace Space_Message_Proxy.Document;

public class DocumentCreatedPayload
{
    public string Document { get; private set; }
    public DocumentCreatedMeta Meta { get; private set; }

    public DocumentCreatedPayload(DocumentCreatedPayloadDto dto)
    {
        Document = dto.Document;
        Meta = new DocumentCreatedMeta(dto.Meta);
    }
}