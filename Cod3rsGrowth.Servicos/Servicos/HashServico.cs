using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Cod3rsGrowth.Infra;
using System.Drawing;
using System.Net.Mail;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class HashServico
    {
        public static string GerarSenhaEncriptada(string senhaBasica)
        {
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(Configuracao.Secret));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(senhaBasica));

            var senhaHash = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                senhaHash.Append(hashBytes[i].ToString("x2"));
            }

            return senhaHash.ToString();
        }

        public static bool Comparar(string senhaEncriptada, string senhaBasica)
        {
            var senhaUsuarioHash = GerarSenhaEncriptada(senhaBasica);
            var comparacao = senhaEncriptada == senhaUsuarioHash;
            return comparacao;
        }
    }
}