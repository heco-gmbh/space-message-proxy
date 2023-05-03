namespace Space_Message_Proxy.Document;

public class DocumentCreated
{
    public DocumentCreatedPayload Payload { get; private set; }

    public DocumentCreated(DocumentCreatedDto dto)
    {
        Payload = new DocumentCreatedPayload(dto.Payload);

    }

    public Message ToMessage(string hostname)
    {
        return new Message(
            $"\n*{Payload.Meta.Principal.Name} hat ein Dokument erstellt:* :bookmark_tabs: \n\n *{Payload.Document}* \n ");

    }


}