namespace Application.DTOs.Auth
{
    public class AuthResponse
    {
        public string Message { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}
