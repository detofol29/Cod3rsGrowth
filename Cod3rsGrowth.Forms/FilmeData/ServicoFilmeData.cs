using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Forms
{
    static public class ServicoFilmeData
    {
        public static List<FilmeData> ConverteFilmeParaData(List<Filme> filmes)
        {
            var data = new List<FilmeData>();
            foreach (var filme in filmes)
            {
                var filmeData = new FilmeData(filme);
                data.Add(filmeData);
            }
            return data;
        }
    }
}