var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/teste", (User user) =>
{
    if(!user.ValidateUser()) return Results.BadRequest();

    if(!user.AuthenticateUser()) return Results.Unauthorized();

    return Results.Ok();
});

app.Run();

public class User
{
    public string Name { get; set; }
    public string Token { get; set; }
    public string Phone { get; set; }

    public bool ValidateUser()
    {
        if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Token)) return false;

        return true;
    }
    public bool AuthenticateUser()
    {
        if (!Name.Equals("admin") || !Token.Equals("access_token")) return false;

        return true;
    }
}