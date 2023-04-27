using System.Net.Http.Headers;
using Space_Message_Proxy;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Urls.Add("https://0.0.0.0:443");

app.MapPost("/issueCreated", async (context) =>
{ 
    await IssueCreatedHandler.Handle(context);
});

app.Run();