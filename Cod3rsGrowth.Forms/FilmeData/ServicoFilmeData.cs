using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Extensoes;
using System.IO;
using System.Windows.Forms;

namespace Cod3rsGrowth.Forms
{
    static public class ServicoFilmeData
    {
        public static List<FilmeData> ConverteFilmeParaData(List<Filme> filmes)
        {
            var data = new List<FilmeData>();
            foreach (var filme in filmes)
            {
                var filmeData = CriarFilmeData(filme);
                data.Add(filmeData);
            }
            return data;
        }

        public static FilmeData CriarFilmeData(Filme filme)
        {
            var filmeData = new FilmeData()
            {
                Id = filme.Id,
                Titulo = filme.Titulo,
                DataDeLancamento = filme.DataDeLancamento,
                Nota = filme.Nota,
                Duracao = filme.Duracao,
                Diretor = filme.Diretor,

                DisponivelNoPlano = filme.DisponivelNoPlano ? "Disponível" : "Não Disponível",
                EmCartaz = filme.EmCartaz ? "Sim" : "Não",

                Genero = ExtensaoDosEnuns.ObterDescricao(filme.Genero),
                Classificacao = ExtensaoDosEnuns.ObterDescricao(filme.Classificacao)
            };

            return filmeData;
        }

        public static Filme ConverterParaFilme(FilmeData data)
        {
            var genero = Enum.GetValues(typeof(GeneroEnum))
                .Cast<Enum>()
                .Where(genero => ExtensaoDosEnuns.ObterDescricao(genero) == data.Genero)
                .Select(g => g)
                .First();

            var classificacao = Enum.GetValues(typeof(ClassificacaoIndicativa))
                .Cast<Enum>()
                .Where(classificacao => ExtensaoDosEnuns.ObterDescricao(classificacao) == data.Classificacao)
                .Select(c => c)
                .First();

            var filme = new Filme()
            {
                Id = data.Id,
                Titulo = data.Titulo,
                Diretor = data.Diretor,
                Nota = data.Nota,
                Duracao = data.Duracao,
                Genero = (GeneroEnum)genero,
                Classificacao = (ClassificacaoIndicativa)classificacao,
                DataDeLancamento = data.DataDeLancamento
            };

            return filme;
        }
    }
}