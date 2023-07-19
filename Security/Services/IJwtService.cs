namespace Security.Services
{
    public interface IJwtService
    {
        string GenerateToken(string userid);
    }
}
