using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cod3rsGrowth.Infra.Servicos;

public static class TokenServico
{
    public static string GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuracao.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(2),
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.NickName),
                new Claim(ClaimTypes.Role, usuario.Plano.ToString()) 
            }),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    public static string retorna()
    {
        ///PROBLEMA!!!
        return @"C:\Users\Usuario\Desktop\Cod3rsGrowth\Cod3rsGrowth\Cod3rsGrowth.Infra\Servicos\tokens.txt";
    }

    public static bool VerificarValidadeToken(string token, Usuario usuario)
    {
        var chave = Encoding.ASCII.GetBytes(Configuracao.Secret);
        var handler = new JwtSecurityTokenHandler();
        var tokenS = handler.ReadToken(token) as JwtSecurityToken;
        var validacoes = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(chave),
            ValidateIssuer = false,
            ValidateAudience = false
        };
        try
        {
            var claims = handler.ValidateToken(token, validacoes, out var tokenSecure);
            if (claims.Identity.Name == usuario.NickName)
            {
                return true;
            }
            else return false;
        }
        catch
        {
            return false;
        }
    }
}