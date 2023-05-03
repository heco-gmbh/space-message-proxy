using System.Net.Http.Headers;

namespace Space_Message_Proxy;

public class IssueStatusChangeHandler
{
    public static async Task<IResult> Handle(HttpContext context)
    {
        var issueStatusChange = new IssueStatusChange(await context.Request.ReadFromJsonAsync<IssueStatusChangeDto>());
        var filter = context.Request.Query["filter"];
        if (issueStatusChange?.Payload == null)
        {
            return TypedResults.Problem("Cannot Parse Body", "", 400);
        }
        if (filter.ToString() != "" && filter.ToString() != issueStatusChange.Payload.Status.New.Name)
        {
            return TypedResults.Ok();
        }
        var slackUrl = context.Request.Headers["x-slack-url"].ToString();
        var hostName = context.Request.Headers["x-space-url"].ToString();
        
       
        var bearerToken = context.Request.Headers.Authorization;
        
        var client = new HttpClient();
        var request = new HttpRequestMessage();
        
        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(slackUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        request.Content = JsonContent.Create(issueStatusChange.ToMessage(hostName));
        return TypedResults.Ok(await client.SendAsync(request));
    }
}