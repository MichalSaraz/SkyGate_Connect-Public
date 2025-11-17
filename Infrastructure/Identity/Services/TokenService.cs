using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Identity.Interfaces;
using Core.Identity.Entities;
using Infrastructure.Identity.Services.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity.Services;

/// <inheritdoc cref="ITokenService"/>
public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;
    private readonly ILogger<TokenService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenService"/>.
    /// </summary>
    /// <param name="config">Application configuration containing token settings.</param>
    /// <param name="logger">Logger for logging token-related events.</param>
    /// <remarks>The constructor initializes the symmetric security key used for token signing.</remarks>
    public TokenService(IConfiguration config, ILogger<TokenService> logger)
    {
        _config = config;
        _logger = logger;

        var rawKey = _config["Token:Key"] ?? string.Empty;
        if (string.IsNullOrWhiteSpace(rawKey))
        {
            _logger.TokenKeyMissing();
        }

        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(rawKey));
    }

    /// <inheritdoc />
    public string CreateToken(AppUser user)
    {
        _logger.TokenCreating(user.UserName ?? string.Empty, user.Role.ToString());
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
        };

        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = credentials,
            Issuer = _config["Token:Issuer"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        _logger.TokenIssued(tokenDescriptor.Issuer, tokenDescriptor.Expires.Value);

        return tokenHandler.WriteToken(token);
    }
}

