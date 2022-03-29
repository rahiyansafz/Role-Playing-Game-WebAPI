namespace WebApiJumpStart.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}
