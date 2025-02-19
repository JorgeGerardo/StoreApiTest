using Bussiness.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StoreApiTest.Services
{
    public class TokenService
    {
        private static int tokenDaysDuration = 100;

        public static string GenerateToken(User user, JWTConfig JWT)
        {
            List<Claim> claims = GetDefaultClaims(user);

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT.Key));
            SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken Token = new JwtSecurityToken(
                    JWT.Issuer,
                    JWT.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddDays(tokenDaysDuration),
                    signingCredentials: signIn
            );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        private static List<Claim> GetDefaultClaims(User user)
        {
            return new List<Claim>()
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("role", user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString()),
            };
        }
        public static string EncrypBySHA256(string password)
        {
            SHA256 sha256 = SHA256.Create();
            UTF8Encoding encoding = new UTF8Encoding();
            StringBuilder sb = new StringBuilder();

            byte[] stream = sha256.ComputeHash(encoding.GetBytes(password));

            //bytes to hex
            for (int i = 0; i < stream.Length; i++)
                sb.AppendFormat("{0:x2}", stream[i]);

            return sb.ToString();
        }

    }

    public class JWTConfig
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
    }

}
