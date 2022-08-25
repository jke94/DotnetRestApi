namespace DotnetRestApi.Services
{
    #region using

    using DotnetRestApi.Abstractions;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    #endregion

    public interface ITokenHandlerService
    {
        string GenerateJwtToken(ITokenParameters parameters);
    }

    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly JwtConfig _jwtConfig;

        public TokenHandlerService(IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        public string GenerateJwtToken(ITokenParameters parameters)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var descriptorToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( new[]
                {
                    new Claim("id", parameters.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, parameters.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, parameters.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(6), // Cuando queremos que expire.
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(descriptorToken);

            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
