using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace Cod3rsGrowth.Infra.Servicos;

public static class TokenServico
{
    public static string GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler(); //Utilizada para gerar um token baseado em algumas informações
        var key = Encoding.ASCII.GetBytes(Configuracao.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(2),
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.NickName),
                new Claim(ClaimTypes.Role, usuario.Plano.ToString()) // Definindo o Role como o plano do usuario
            }),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public static string retorna()
    {
        return @"C:\Users\Usuario\Desktop\Cod3rsGrowth\Cod3rsGrowth\Cod3rsGrowth.Infra\Servicos\tokens.txt";
    }
}