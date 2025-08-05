using Application.DTOs.Auth;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IEmailService _emailService;

    public AuthService(AppDbContext context, ITokenService tokenService, IEmailService emailService)
    {
        _tokenService = tokenService;
        _context = context;
        _emailService = emailService;
    }

    public async Task<string> RegisterAsync(RegisterRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            throw new Exception("Bu email adresi zaten kayıtlı.");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var emailToken = Guid.NewGuid().ToString();

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = hashedPassword,
            IsEmailConfirmed = false,
            EmailConfirmationToken = emailToken,
            EmailConfirmationTokenExpires = DateTime.UtcNow.AddHours(24)
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var verifyLink = $"http://localhost:4200/verify-email?token={emailToken}";
        var body = $@"
        <h2>Arıcım'a Hoş Geldiniz</h2>
        <p>Lütfen e-posta adresinizi doğrulamak için aşağıdaki bağlantıya tıklayın:</p>
        <a href='{verifyLink}'>Hesabımı Doğrula</a>";

        await _emailService.SendEmailAsync(user.Email, "E-posta Doğrulama", body);

        return "Kayıt başarılı. Lütfen e-posta adresinizi doğrulayın.";
    }


    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new Exception("Email veya parola hatalı.");

        if (!user.IsEmailConfirmed)
            throw new Exception("Lütfen önce e-posta adresinizi doğrulayın.");

        var token = _tokenService.GenerateToken(user);

        return new AuthResponse
        {
            Message = "Giriş başarılı.",
            Token = token
        };
    }

    public async Task<string> VerifyEmailAsync(string token)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.EmailConfirmationToken == token.Trim() &&
            u.EmailConfirmationTokenExpires > DateTime.UtcNow);

        if (user == null)
            throw new Exception("Token geçersiz veya süresi dolmuş.");

        user.IsEmailConfirmed = true;
        user.EmailConfirmationToken = "";
        user.EmailConfirmationTokenExpires = DateTime.MinValue;

        await _context.SaveChangesAsync();

        return "E-posta başarıyla doğrulandı.";
    }

}

