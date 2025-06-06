var builder = WebApplication.CreateBuilder(args);
// Adding AddHttpLogging to the service collection
builder.Services.AddHttpLogging((o) => { });

var app = builder.Build();

// Adding UseHttpLogging middleware to the request pipeline
app.UseHttpLogging();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello Amr!");
app.MapGet("/home", () => "This is Home Page!");

app.Run();
