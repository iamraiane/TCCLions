namespace TCCLions.API.Application.Services;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string storedHash, string password);
}

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string storedHash, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }
}
