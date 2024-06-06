using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Teste.TestesUnitarios;

public class TesteFilmeServico : TesteBase
{
    private readonly FilmeServicos _servicos;
    public TesteFilmeServico()
    {
        _servicos = serviceProvider.GetService<FilmeServicos>() ?? throw new Exception("servico nao encontrado");
    }

    private Filme ObterFilmeEsperado()
    {
        return new Filme() { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre };
    }

    [Fact]
    public void ao_ObterTodos_retorna_lista_com_doze_filmes()
    {
        const int valorEsperado = 12;

        _servicos.Inserir(new Filme { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre});
        _servicos.Inserir(new Filme { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze});
        _servicos.Inserir(new Filme { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre});
        _servicos.Inserir(new Filme { Id = 4, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze});
        _servicos.Inserir(new Filme { Id = 5, Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze});
        _servicos.Inserir(new Filme { Id = 6, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze});
        _servicos.Inserir(new Filme { Id = 7, Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis});
        _servicos.Inserir(new Filme { Id = 8, Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis});
        _servicos.Inserir(new Filme { Id = 9, Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito});
        _servicos.Inserir(new Filme { Id = 10, Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze});
        _servicos.Inserir(new Filme { Id = 11, Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito});
        _servicos.Inserir(new Filme { Id = 12, Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze});

        var lista = _servicos.ObterTodos();

        Assert.NotEmpty(lista);
        Assert.Equal(valorEsperado, lista.Count());
    }

    [Fact]
    public void ao_ObterPorId_retorna_filme_com_id_igual_a_3()
    {
        _servicos.Inserir(new Filme { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.Inserir(new Filme { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze });
        _servicos.Inserir(new Filme { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.Inserir(new Filme { Id = 4, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 5, Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 6, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 7, Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.Inserir(new Filme { Id = 8, Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.Inserir(new Filme { Id = 9, Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.Inserir(new Filme { Id = 10, Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 11, Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.Inserir(new Filme { Id = 12, Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze });
        var filmeEsperado = ObterFilmeEsperado();

        var filmeEncontrado = _servicos.ObterPorId(3);

        Assert.NotNull(filmeEncontrado);
        Assert.Equivalent(filmeEsperado, filmeEncontrado);
    }

    public void ao_ObterPorId_retorna_mensagem_de_erro_quando_id_nao_encontrado()
    {
        _servicos.Inserir(new Filme { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.Inserir(new Filme { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze });
        _servicos.Inserir(new Filme { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.Inserir(new Filme { Id = 4, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 5, Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 6, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 7, Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.Inserir(new Filme { Id = 8, Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.Inserir(new Filme { Id = 9, Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.Inserir(new Filme { Id = 10, Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 11, Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.Inserir(new Filme { Id = 12, Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze });

        var mensagemEsperada = "Filme nao encontrado";
        var excecao = Assert.Throws<Exception>(() => _servicos.ObterPorId(13));

        Assert.Equal(mensagemEsperada, excecao.Message);
    }
}