using System.Net.Http.Headers;

namespace Space_Message_Proxy.Document;

public class DocumentCreatedHandler
{
    public static async Task<IResult> Handle(HttpContext context)
    {
        var documentCreated = new DocumentCreated(await context.Request.ReadFromJsonAsync<DocumentCreatedDto>());
        if (documentCreated?.Payload == null)
        {
            return TypedResults.Problem("Cannot Parse Body", "", 400);
        }
        var slackUrl = context.Request.Headers["x-slack-url"].ToString();
        var hostName = context.Request.Headers["x-space-url"].ToString();
        var bearerToken = context.Request.Headers.Authorization;
        
        var client = new HttpClient();
        var request = new HttpRequestMessage();
        
        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(slackUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        request.Content = JsonContent.Create(documentCreated.toMessage(hostName));
        return TypedResults.Ok(await client.SendAsync(request));
    }
}
