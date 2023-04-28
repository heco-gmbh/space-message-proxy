using System.Net.Http.Headers;

namespace Space_Message_Proxy;

public class IssueCreatedHandler
{
    public static async Task<IResult> Handle(HttpContext context)
    {
        var issue = new IssueCreated(await context.Request.ReadFromJsonAsync<IssueCreatedDto>());
        if (issue?.Payload == null)
        {
            return TypedResults.Problem("Cannot Parse Body", "", 400);
        }
        var slackUrl = context.Request.Headers["x-slack-url"].ToString();
        var hostName = context.Request.Headers["x-space-url"].ToString();
        if (hostName == "")
        {
            hostName = $"{context.Request.Scheme}://{context.Request.Host}";
        }

        var bearerToken = context.Request.Headers.Authorization;
        var client = new HttpClient();
        var request = new HttpRequestMessage();
        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(slackUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        request.Content = JsonContent.Create(issue.toMessage(hostName));
        return TypedResults.Ok(await client.SendAsync(request));
    }
}