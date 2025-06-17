var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>"devpod2")
    .WithName("GetAppName");


app.MapGet("/test", () =>
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://server:5020");
        
        var response = client.GetAsync("weatherforecast").Result;
        return response;
    })
    .WithName("Test");

app.Run();