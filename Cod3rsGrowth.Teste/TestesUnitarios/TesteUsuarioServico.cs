using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Teste.TestesUnitarios;

public class TesteUsuarioServico : TesteBase
{
    private readonly UsuarioServicos _servicos;
    public TesteUsuarioServico()
    {
        _servicos = serviceProvider.GetService<UsuarioServicos>() ?? throw new Exception("Servico nao encontrado");
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
        _servicos.Inserir(new() { Nome = "Gabriel Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, Senha = "123", NickName = "Detofol29" });
        _servicos.Inserir(new() { Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, Senha = "123", NickName = "SilvaMarcosPaulo" });
        _servicos.Inserir(new() { Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens" });
        _servicos.Inserir(new() { Nome = "André", IdUsuario = 4, Plano = PlanoEnum.Free, Senha = "123", NickName = "AndrezinDoGrau" });

        var usuarioEncontrado = _servicos.ObterPorId(3);
        var usuarioEsperado = ObterUsuarioEsperado();

        Assert.Equivalent(usuarioEsperado, usuarioEncontrado);
    }

    [Fact]
    public void ao_ObterPorId_retorna_mensagem_de_erro_quando_id_nao_encontrado()
    {
        _servicos.Inserir(new() { Nome = "Gabriel Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, Senha = "123", NickName = "Detofol29" });
        _servicos.Inserir(new() { Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, Senha = "123", NickName = "SilvaMarcosPaulo" });
        _servicos.Inserir(new() { Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens" });
        _servicos.Inserir(new() { Nome = "André", IdUsuario = 4, Plano = PlanoEnum.Free, Senha = "123", NickName = "AndrezinDoGrau" });

        var mensagemEsperada = "Usuario nao encontrado";
        var excecao = Assert.Throws<Exception>(() => _servicos.ObterPorId(5));

        Assert.Equal(mensagemEsperada, excecao.Message);
    }
}