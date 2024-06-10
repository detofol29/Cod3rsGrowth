using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Validacoes;
using System.Globalization;

namespace Cod3rsGrowth.Teste.TestesUnitarios;

public class TesteUsuarioServico : TesteBase
{
    private readonly UsuarioServicos _servicos;
    public TesteUsuarioServico()
    {
        _servicos = serviceProvider.GetService<UsuarioServicos>() ?? throw new Exception("Serviço não encontrado!");
    }

    private Usuario ObterUsuarioEsperado()
    {
        return new Usuario() { Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens" };
    }

    [Fact]
    public void ao_ObterTodos_retorna_lista_com_quatro_usuarios()
    {
        _servicos.Inserir(new() {Nome = "Gabriel Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, Senha = "123", NickName = "Detofol29"});
        _servicos.Inserir(new() {Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, Senha = "123", NickName = "SilvaMarcosPaulo"});
        _servicos.Inserir(new() {Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens"});
        _servicos.Inserir(new() {Nome = "André", IdUsuario = 4, Plano = PlanoEnum.Free, Senha = "123", NickName = "AndrezinDoGrau"});
        var listaEsperada = TabelasSingleton.ObterInstanciaUsuarios;

        var lista = _servicos.ObterTodos();

        Assert.NotEmpty(lista);
        Assert.Equal(listaEsperada.Count(), lista.Count());
    }

    [Fact]
    public void ao_ObterPorId_retorna_usuario_com_id_igual_a_3()
    {
        const int idUsuario = 3;

        _servicos.Inserir(new() { Nome = "Gabriel Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, Senha = "123", NickName = "Detofol29" });
        _servicos.Inserir(new() { Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, Senha = "123", NickName = "SilvaMarcosPaulo" });
        _servicos.Inserir(new() { Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens" });
        _servicos.Inserir(new() { Nome = "André", IdUsuario = 4, Plano = PlanoEnum.Free, Senha = "123", NickName = "AndrezinDoGrau" });

        var usuarioEncontrado = _servicos.ObterPorId(idUsuario);
        var usuarioEsperado = ObterUsuarioEsperado();

        Assert.Equivalent(usuarioEsperado, usuarioEncontrado);
    }

    [Fact]
    public void ao_ObterPorId_retorna_mensagem_de_erro_quando_id_nao_encontrado()
    {
        const int idNaoExistente = 5;

        _servicos.Inserir(new() { Nome = "Gabriel Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, Senha = "123", NickName = "Detofol29" });
        _servicos.Inserir(new() { Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, Senha = "123", NickName = "SilvaMarcosPaulo" });
        _servicos.Inserir(new() { Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens" });
        _servicos.Inserir(new() { Nome = "André", IdUsuario = 4, Plano = PlanoEnum.Free, Senha = "123", NickName = "AndrezinDoGrau" });

        var mensagemEsperada = "Usuario nao encontrado";
        var excecao = Assert.Throws<Exception>(() => _servicos.ObterPorId(idNaoExistente));

        Assert.Equal(mensagemEsperada, excecao.Message);
    }

    [Fact]
    public void ao_criar_usuario_sem_nome_retorna_mensagem_de_erro()
    {
        const int id = 3;
        const string mensagemEsperada = "O campo 'Nome' não pode estar vazio!";

        Usuario usuario = new()
        {
            Nome = "",
            IdUsuario = id,
            NickName = "Robertinho",
            Senha = "123456"
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Nome")?.ErrorMessage;

        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    [Fact]
    public void ao_criar_usuario_sem_nickname_retorna_mensagem_de_erro()
    {
        const int id = 3;
        const string mensagemEsperada = "O campo 'nome de usuário' não pode estar vazio!";

        Usuario usuario = new()
        {
            Nome = "Robertinho",
            IdUsuario = id,
            NickName = "",
            Senha = "123456"
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "NickName")?.ErrorMessage;

        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    [Fact]
    public void ao_criar_usuario_sem_senha_retorna_mensagem_de_erro()
    {
        const int id = 3;
        const string mensagemEsperada = "O campo 'senha' não pode estar vazio!";

        Usuario usuario = new()
        {
            Nome = "Roberto",
            IdUsuario = id,
            NickName = "Robertinho",
            Senha = ""
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Senha")?.ErrorMessage;

        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    [Fact]
    public void ao_criar_usuario_com_senha_inferior_a_6_caracteres_retorna_mensagem_de_erro()
    {
        const int id = 3;
        const string mensagemEsperada = "O campo 'senha' deve ter no mínimo 6 digitos!";

        Usuario usuario = new()
        {
            Nome = "Roberto",
            IdUsuario = id,
            NickName = "Robertinho",
            Senha = "12345"
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Senha")?.ErrorMessage;

        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    [Fact]
    public void ao_criar_usuario_com_id_negativo_retorna_mensagem_de_erro()
    {
        const int idNegativo = -1;
        const string mensagemEsperada = "O campo 'Id' precisa conter um número positivo!";

        Usuario usuario = new()
        {
            Nome = "Roberto",
            IdUsuario = idNegativo,
            NickName = "Robertinho",
            Senha = "12345"
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "IdUsuario")?.ErrorMessage;

        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    //[Fact]
    public void ao_criar_usuario_sem_id_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "Id nao pode ser nulo";

        Usuario usuario = new()
        {
            Nome = "Roberto",
            NickName = "Robertinho",
            Senha = "12345"
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "IdUsuario")?.ErrorMessage;

        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }
}