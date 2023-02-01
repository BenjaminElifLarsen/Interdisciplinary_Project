namespace Domain.DL.CQRS.Commands.Users;
internal class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
