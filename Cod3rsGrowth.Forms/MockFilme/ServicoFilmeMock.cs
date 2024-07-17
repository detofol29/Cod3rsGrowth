using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth_Domínio.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Forms.MockFilme
{
    static public class ServicoFilmeMock
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

        //public static List<Filme> ConverteDataParaFilme(List<FilmeData> data)
        //{
        //    var filmes = new List<Filme>();
        //    foreach (var filmeData in data)
        //    {
        //        var filme = new Filme();
        //        filme.Id = filmeData.Id;
        //        filme.Titulo = filmeData.Titulo;
        //        filme.DataDeLancamento = filmeData.DataDeLancamento;
        //        filme.EmCartaz = filmeData.EmCartaz;
        //        filme.Nota = filmeData.Nota;
        //        filme.Duracao = filmeData.Duracao;
        //        filme.Diretor = filmeData.Diretor;
        //        if(filmeData.DisponivelNoPlano == "Sim")
        //        {
        //            filme.DisponivelNoPlano = true;
        //        }
        //        else
        //        {
        //            filme.DisponivelNoPlano = false;
        //        }
        //        if(filmeData.)
        //        filme.Genero = ExtensaoDosEnuns.ObterGeneroEnum(filmeData.Genero);
        //        filme.Classificacao = ExtensaoDosEnuns.ObterClassificacaoEnum(filmeData.Classificacao);
                
        //    }
        //    return filmes;
        //}
    }
}
