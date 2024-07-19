using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Teste.RepositoriosMock;

namespace Cod3rsGrowth.Teste.TestesUnitarios;

public class TesteUsuarioServico : TesteBase
{
    private readonly UsuarioRepositorioMock _servicos;
    public TesteUsuarioServico()
    {
        _servicos = serviceProvider.GetService<UsuarioRepositorioMock>() ?? throw new Exception("Serviço não encontrado!");
        _servicos.ObterTodos(null).Clear();
    }

    private Usuario ObterUsuarioEsperado()
    {
        return new Usuario() { Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens" };
    }

    private List<Usuario> ObterUsuarios()
    {
        List<Usuario> usuarios = new()
        {
            new Usuario() {Nome = "Marcos Paulo", NickName = "MarcosPaulo", Senha = "Abc12345", Plano = PlanoEnum.Free},
            new Usuario() {Nome = "Rubens", NickName = "Rubinho09", Senha = "Abc12345", Plano = PlanoEnum.Free},
            new Usuario() {Nome = "André", NickName = "AndreGamePlayss", Senha = "Abc12345", Plano = PlanoEnum.Premium},
            new Usuario() {Nome = "Gabriel", NickName = "Detofol299", Senha = "Abc12345", Plano = PlanoEnum.Nerd},
        };

        foreach(var usuario in usuarios)
        {
            _servicos.CriarUsuario(usuario);
        }
        return usuarios;
    }

    private void RemoverUsuarios(List<Usuario> usuarios)
    {
        foreach(var usuario in usuarios)
        {
            _servicos.Remover(usuario.IdUsuario);
        }
    }

    [Fact]
    public void ao_ObterTodos_retorna_lista_com_quatro_usuarios()
    {
        _servicos.Inserir(new() { Nome = "Gabriel Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, Senha = "123", NickName = "Detofol7" });
        _servicos.Inserir(new() { Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, Senha = "123", NickName = "SilvaMarcosPaulo" });
        _servicos.Inserir(new() { Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens" });
        _servicos.Inserir(new() { Nome = "André", IdUsuario = 4, Plano = PlanoEnum.Free, Senha = "123", NickName = "AndrezinDoGrau" });
        var listaEsperada = TabelasSingleton.ObterInstanciaUsuarios;

        var lista = _servicos.ObterTodos(null);

        Assert.NotEmpty(lista);
        Assert.Equal(listaEsperada.Count(), lista.Count());
    }

    [Fact]
    public void ao_ObterPorId_retorna_usuario_com_id_igual_ao_esperado()
    {
        const int idUsuarioEsperado = 3;

        RemoverUsuarios(_servicos.ObterTodos(null));
        _servicos.Inserir(new() { Nome = "Gabriel Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, Senha = "123", NickName = "Detofol29" });
        _servicos.Inserir(new() { Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, Senha = "123", NickName = "SilvaMarcosPaulo" });
        _servicos.Inserir(new() { Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens" });
        _servicos.Inserir(new() { Nome = "André", IdUsuario = 4, Plano = PlanoEnum.Free, Senha = "123", NickName = "AndrezinDoGrau" });

        var usuarioEncontrado = _servicos.ObterPorId(idUsuarioEsperado);
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
            Senha = "Abc123456"
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
            Senha = "Abc123456"
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
    public void ao_criar_usuario_com_senha_inferior_ao_minimo_caracteres_retorna_mensagem_de_erro()
    {
        const int id = 3;
        const string mensagemEsperada = "O campo 'senha' deve ter no mínimo 6 digitos!";

        Usuario usuario = new()
        {
            Nome = "Roberto",
            IdUsuario = id,
            NickName = "Robertinho",
            Senha = "Ab123"
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Senha")?.ErrorMessage;

        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    [Fact]
    public void ao_criar_usuario_com_senha_que_nao_possui_uma_letra_maiuscula_retorna_mensagem_de_erro()
    {
        const int id = 3;
        const string mensagemEsperada = "O campo 'senha' deve conter pelo menos uma letra maiúscula!";
        const string senhaSemLetraMaiuscula = "robertinho123";

        Usuario usuario = new()
        {
            Nome = "Roberto",
            IdUsuario = id,
            NickName = "Robertinho",
            Senha = senhaSemLetraMaiuscula
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Senha")?.ErrorMessage;

        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    [Fact]
    public void ao_criar_usuario_com_senha_que_nao_possui_uma_letra_minuscula_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo 'senha' deve conter pelo menos uma letra minuscula!";
        const string senhaSemLetraMinuscula = "ROBERTINHO123";

        Usuario usuario = new()
        {
            Nome = "Roberto",
            NickName = "Robertinho",
            Senha = senhaSemLetraMinuscula
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Senha")?.ErrorMessage;

        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    [Fact]
    public void ao_criar_usuario_com_senha_sem_numero_retorna_mensagem_de_erro()
    {
        const int id = 3;
        const string mensagemEsperada = "O campo 'senha' deve conter pelo menos um número!";
        const string senhaSemNumero = "Robertinha";

        Usuario usuario = new()
        {
            Nome = "Roberto",
            IdUsuario = id,
            NickName = "Robertinho",
            Senha = senhaSemNumero
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Senha")?.ErrorMessage;

        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    [Fact]
    public void ao_criar_usuario_com_nome_contendo_numero_retorna_mensagem_de_erro()
    {
        const int id = 3;
        const string mensagemEsperada = "O campo 'Nome' não deve conter números!";
        const string nomeComNumero = "Roberto7";

        Usuario usuario = new()
        {
            Nome = nomeComNumero,
            IdUsuario = id,
            NickName = "Robertinho",
            Senha = "Abc12345"
        };

        var resultado = _servicos.CriarUsuario(usuario);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Nome")?.ErrorMessage;
        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    [Fact]
    public void ao_editar_usuario_retorna_usuario_com_nome_editado()
    {
        Usuario usuarioBase = new()
        {
            Nome = "Criss Byuither",
            NickName = "Robertinhoo",
            Senha = "Abc12345"
        };

        _servicos.CriarUsuario(usuarioBase); 
        var idBase = usuarioBase.IdUsuario;
        Usuario usuarioEditado = new()
        {
            Nome = "Criss Byuither Silva",
            NickName = "Robertinhoo",
            Senha = "Abc12345",
            IdUsuario = idBase
        };

        _servicos.Editar(usuarioEditado);
        var usuarioEncontrado = _servicos.ObterPorId(idBase);

        Assert.Equal(usuarioEditado.Nome, usuarioEncontrado.Nome);
        Assert.Equivalent(usuarioBase, usuarioEncontrado);
    }

    [Fact]
    public void ao_editar_usuario_sem_nome_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo 'Nome' não pode estar vazio!";

        Usuario usuarioBase = new()
        {
            Nome = "Criss Byuither",
            NickName = "Robertinhooo",
            Senha = "Abc12345"
        };

        Usuario usuarioEditado = new()
        {
            Nome = "",
            NickName = "Robertinhooo",
            Senha = "Abc12345"
        };

        _servicos.CriarUsuario(usuarioBase);
        var idBase = usuarioBase.IdUsuario;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(usuarioEditado));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Fact]
    public void ao_editar_usuario_com_nome_contendo_numeros_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo 'Nome' não deve conter números!";

        Usuario usuarioBase = new()
        {
            Nome = "Criss Byuither",
            NickName = "Robertinho",
            Senha = "Abc12345"
        };

        Usuario usuarioEditado = new()
        {
            Nome = "Criss Byuither77",
            NickName = "Robertinho",
            Senha = "Abc12345"
        };

        _servicos.CriarUsuario(usuarioBase);
        var idBase = usuarioBase.IdUsuario;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(usuarioEditado));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Fact]
    public void ao_editar_usuario_com_nickname_vazio_retorna_mensagem_de_erro()
    {
        const string mensagemDeErro = "O campo 'nome de usuário' não pode estar vazio!";
        Usuario usuarioBase = new()
        {
            Nome = "Criss Byuither",
            NickName = "Robertinho",
            Senha = "Abc12345"
        };

        Usuario usuarioEditado = new()
        {
            Nome = "Criss Byuither",
            NickName = "",
            Senha = "Abc12345"
        };

        _servicos.CriarUsuario(usuarioBase);
        var idBase = usuarioBase.IdUsuario;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(usuarioEditado));
        Assert.Equal(mensagemDeErro, ex.Message);
    }

    [Fact]
    public void ao_editar_usuario_com_senha_vazio_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo 'senha' não pode estar vazio!";

        Usuario usuarioBase = new()
        {
            Nome = "Criss Byuither",
            NickName = "Robertinho",
            Senha = "Abc12345"
        };

        Usuario usuarioEditado = new()
        {
            Nome = "Carlos",
            NickName = "Robertinho",
            Senha = ""
        };

        _servicos.CriarUsuario(usuarioBase);
        var idBase = usuarioBase.IdUsuario;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(usuarioEditado));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Fact]
    public void ao_editar_usuario_com_senha_sem_letra_maiuscula_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo 'senha' deve conter pelo menos uma letra maiúscula!";

        Usuario usuarioBase = new()
        {
            Nome = "Criss Byuither",
            NickName = "Robertinho",
            Senha = "Abc12345"
        };

        Usuario usuarioEditado = new()
        {
            Nome = "Carlos",
            NickName = "Robertinho",
            Senha = "abc12345"
        };

        _servicos.CriarUsuario(usuarioBase);
        var idBase = usuarioBase.IdUsuario;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(usuarioEditado));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Fact]
    public void ao_editar_usuario_com_senha_sem_letra_minuscula_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo 'senha' deve conter pelo menos uma letra minuscula!";

        Usuario usuarioBase = new()
        {
            Nome = "Criss Byuither",
            NickName = "Robertinho",
            Senha = "Abc12345"
        };

        Usuario usuarioEditado = new()
        {
            Nome = "Carlos",
            NickName = "Robertinho",
            Senha = "ABC12345"
        };

        _servicos.CriarUsuario(usuarioBase);
        var idBase = usuarioBase.IdUsuario;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(usuarioEditado));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Fact]
    public void ao_editar_usuario_com_senha_sem_numero_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo 'senha' deve conter pelo menos um número!";

        Usuario usuarioBase = new()
        {
            Nome = "Criss Byuither",
            NickName = "Robertinho",
            Senha = "Abc12345"
        };

        Usuario usuarioEditado = new()
        {
            Nome = "Carlos",
            NickName = "Robertinho",
            Senha = "AbcDeFGh"
        };

        _servicos.CriarUsuario(usuarioBase);
        var idBase = usuarioBase.IdUsuario;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(usuarioEditado));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Fact]
    public void ao_remover_usuario_da_lista_retorna_lista_com_um_item_a_menos_ao_ObterTodos()
    {
        const int quantidadePosRemocao = 3;
        const int indiceIdParaRemocao = 3;

        RemoverUsuarios(_servicos.ObterTodos(null));
        var usuarios = ObterUsuarios();
        var idParaRemocao = usuarios[indiceIdParaRemocao].IdUsuario;
        _servicos.Remover(idParaRemocao);
        var listaDeUsuariosPosRemocao = _servicos.ObterTodos(null);

        Assert.Equal(quantidadePosRemocao, listaDeUsuariosPosRemocao.Count());
    }

    [Theory]
    [InlineData(-12)]
    [InlineData(100)]
    [InlineData(0)]
    public void ao_remover_usuario_passando_id_invalido_retorna_mensagem_de_erro(int id)
    {
        const string mensagemEsperada = "Usuario nao encontrado";
        var idInvalido = id;

        ObterUsuarios();

        var ex = Assert.Throws<Exception>(() => _servicos.Remover(idInvalido));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Theory]
    [InlineData(PlanoEnum.Nerd, 1)]
    [InlineData(PlanoEnum.Free, 2)]
    [InlineData(PlanoEnum.Premium, 1)]
    public void ao_obterTodos_com_filtro_de_Plano_retorna_quantidade_de_usuarios_correspondente(PlanoEnum plano, int quantidade)
    {
        var quantidadeEsperada = quantidade;
        var planoEsperado = plano;
        RemoverUsuarios(_servicos.ObterTodos(null));
        ObterUsuarios();

        FiltroUsuario filtro = new()
        {
            FiltroPlano = planoEsperado
        };

        var usuariosObtidos = _servicos.ObterTodos(filtro);

        Assert.Equal(quantidadeEsperada, usuariosObtidos.Count());
    }
}