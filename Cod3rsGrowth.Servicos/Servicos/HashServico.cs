using System.Security.Cryptography;
using System.Text;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class HashServico
    {
        public static string GerarSenhaEncriptada(string senhaBasica)
        {
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(ConfiguracaoServico.Secret));
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