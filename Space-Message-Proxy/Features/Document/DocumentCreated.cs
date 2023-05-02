namespace Space_Message_Proxy.Document;

public class DocumentCreated
{
    public DocumentCreatedPayload Payload { get; set; }

    public DocumentCreated(DocumentCreatedDto dto)
    {
        Payload = new DocumentCreatedPayload(dto.Payload);

    }

    public Message toMessage(string hostname)
    {
        return new Message()
        {
            Text = $"\n*{Payload.Meta.Principal.Name} hat ein Dokument erstellt:* :bookmark_tabs: \n\n *{Payload.Document}* \n "
        };
    }


}