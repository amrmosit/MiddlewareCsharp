var builder = WebApplication.CreateBuilder(args);
// Adding AddHttpLogging to the service collection
builder.Services.AddHttpLogging((o) => { });

var app = builder.Build();
// These middlewares are added by default in minimal APIs (behind the scenes) by dotnet
// app.UseRouting(); // Not needed in minimal APIs
// app.UseAuthentication(); // Not needed in minimal APIs
// app.UseAuthorization(); // Not needed in minimal APIs
// app.UseExceptionHandler(); // Not needed in minimal APIs


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

// This Middleware is added to the request pipeline by default behind the scenes by dotnet
// app.UseEndpoints();

app.Run();
