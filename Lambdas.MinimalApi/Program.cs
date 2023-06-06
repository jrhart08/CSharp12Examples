var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/double", (int number = 0) => number * 2);
app.MapGet("/multiply", (int a = 0, int b = 0) => a * b);

app.Run();