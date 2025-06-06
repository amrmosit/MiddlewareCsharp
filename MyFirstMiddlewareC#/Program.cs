var builder = WebApplication.CreateBuilder(args);
// Adding AddHttpLogging to the service collection
builder.Services.AddHttpLogging((o) => { });

var app = builder.Build();

// Adding UseHttpLogging middleware to the request pipeline
app.UseHttpLogging();

app.UseHttpsRedirection();
// Adding a custom middleware to the request pipeline
app.Use(async (context, next) =>
{
    // logic befor invoking next function
    Console.WriteLine("Middleware executing before the next function.");
    await next.Invoke();
    // logic after invoking next function
    Console.WriteLine("Middleware executing after the next function.");
});
app.MapGet("/", () => "Hello Amr!");
app.MapGet("/home", () => "This is Home Page!");

app.Run();
