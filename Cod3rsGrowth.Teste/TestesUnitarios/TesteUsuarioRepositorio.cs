using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Teste.TestesUnitarios;

public class TesteUsuarioRepositorio : TesteBase
{
    private readonly IUsuarioRepositorio usuarioRepositorio;
    public TesteUsuarioRepositorio()
    {
        usuarioRepositorio = serviceProvider.GetService<IUsuarioRepositorio>() ?? throw new Exception("Repositorio nao encontrado");
    }

    [Fact]
    public void ao_ObterTodos_retorna_lista_com_quatro_usuarios()
    {
        usuarioRepositorio.Inserir(new() {Nome = "Gabriel Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, Senha = "123", NickName = "Detofol29"});
        usuarioRepositorio.Inserir(new() {Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, Senha = "123", NickName = "SilvaMarcosPaulo"});
        usuarioRepositorio.Inserir(new() {Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens"});
        usuarioRepositorio.Inserir(new() {Nome = "André", IdUsuario = 4, Plano = PlanoEnum.Free, Senha = "123", NickName = "AndrezinDoGrau"});
        var listaEsperada = TabelasSingleton.ObterInstanciaUsuarios;

        var lista = usuarioRepositorio.ObterTodos();

        Assert.NotEmpty(lista);
        Assert.Equal(listaEsperada.Count(), lista.Count());
    }
}