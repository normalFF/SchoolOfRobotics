using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using SchoolOfRobotics.Application.Abstractions.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using SchoolOfRobotics.Domain.Users;

namespace SchoolOfRobotics.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _options;

    public JwtTokenGenerator(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

	public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email.Value)
        };

        var newToken = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
			claims: claims,
            null,
			expires: DateTime.Now.AddHours(2),
            signingCredentials: signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(newToken);
    }
}