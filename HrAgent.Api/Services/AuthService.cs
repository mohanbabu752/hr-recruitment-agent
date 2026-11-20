using HrAgent.Api.Data;
using HrAgent.Api.Helpers;
using HrAgent.Api.Interfaces;
using HrAgent.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HrAgent.Api.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _db;
    private readonly JwtHelper _jwt;

    public AuthService(AppDbContext db, JwtHelper jwt)
    {
        _db = db;
        _jwt = jwt;
    }

    public async Task<ApiResponse<AuthResponse>> RegisterAsync(RegisterRequest request)
    {
        if (await _db.Users.AnyAsync(u => u.Email == request.Email))
            return ApiResponse<AuthResponse>.Fail("Email already exists");

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return ApiResponse<AuthResponse>.Ok(ToResponse(user), "Registered successfully");
    }

    public async Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest request)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return ApiResponse<AuthResponse>.Fail("Invalid email or password");

        return ApiResponse<AuthResponse>.Ok(ToResponse(user), "Login successful");
    }

    private AuthResponse ToResponse(User user) => new()
    {
        Token = _jwt.GenerateToken(user),
        Name = user.Name,
        Email = user.Email
    };
}