using System.Net.Http.Headers;
using Space_Message_Proxy;
using Space_Message_Proxy.Document;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Urls.Add("http://0.0.0.0:80");


app.MapPost("/issueCreated", async (context) =>
{ 
    await IssueCreatedHandler.Handle(context);
});

app.MapPost("/documentCreated", async (context) =>
{ 
    await DocumentCreatedHandler.Handle(context);
});
app.Run();