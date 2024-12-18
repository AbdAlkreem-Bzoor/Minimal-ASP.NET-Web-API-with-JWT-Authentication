namespace MinimalAPI___JWT_Authentication.Services
{
    public interface IJwtTokenGenerator
    {
        Task<string?> GenerateToken(string? name, string? password);
        bool ValidateToken(string token);
    }
}
