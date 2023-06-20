using Microsoft.IdentityModel.Tokens;
using OnlineStore.Application.Models;
using OnlineStore.Infraestructure.Models.Usuario;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineStore.Auth.Api.Core
{
    public static class TokenHelper
    {
        static string hola = string.Empty;

        public static TokenInfo GetToken(UsuarioModel usuario, string siginigKey)
        {

            TokenInfo tokenInfo = new TokenInfo();
            // string v;
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(siginigKey);


            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Email,usuario.Correo),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);

            tokenInfo.FechaExpiracion = tokenDescriptor.Expires;
            tokenInfo.Token = tokenHandler.WriteToken(token);

            return tokenInfo;
        }
    }
}
