using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.ServicosToken;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using ValidationException = FluentValidation.ValidationException;
using ValidationFailure = FluentValidation.Results.ValidationFailure;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Cod3rsGrowth.Servicos.Servicos;

public class UsuarioServicos : IUsuarioRepositorio
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IValidator<Usuario> _validator;
    public UsuarioServicos(IUsuarioRepositorio usuarioRepositorio, IValidator<Usuario> validator)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _validator = validator;
    }
    
    public List<Usuario> ObterTodos(FiltroUsuario? filtroUsuario)
    {
        return _usuarioRepositorio.ObterTodos(filtroUsuario);
    }

    public Usuario ObterPorId(int id)
    {
        return _usuarioRepositorio.ObterPorId(id);
    }

    public void Inserir(Usuario usuario)
    {
        _usuarioRepositorio.Inserir(usuario);
    }

    public void AdicionarFilmeNaMinhaLista(Filme filme, Usuario usuario)
    {
        usuario.FilmesDoUsuario.Add(filme);
    }

    public Filme LicenciarFilmePorUsuario(Usuario usuario, Filme filme)
    {
        switch (usuario.Plano)
        {
            case PlanoEnum.Premium:
                filme.DisponivelNoPlano = true;
                break;

            case PlanoEnum.Kids when filme.Classificacao == ClassificacaoIndicativa.livre:
                    filme.DisponivelNoPlano = true;
                break;

            case PlanoEnum.Nerd when filme.Genero == GeneroEnum.Ficcao || filme.Genero == GeneroEnum.Fantasia:
                    filme.DisponivelNoPlano = true;
                break;

            default:
                filme.DisponivelNoPlano = false;
                break;
        }
        return filme;
    }

    public void Remover(int id)
    {
        _usuarioRepositorio.Remover(id);
    }

    public ValidationResult CriarUsuario(Usuario usuario)
    {
        try
        {
            var usuarioVerificar = ObterTodos(new FiltroUsuario() 
            {
                FiltroNome = usuario.NickName 
            })?
            .FirstOrDefault();

            if (usuarioVerificar is not null)
            {
                var mensagemNickNameEmUso = "Esse NickName já está em uso!";
                throw new Exception(mensagemNickNameEmUso);
            }

            usuario.IdUsuario = GerarId();
            _validator.ValidateAndThrow(usuario);
            var senhaEncriptada = HashServico.GerarSenhaEncriptada(usuario.Senha);
            usuario.Senha = senhaEncriptada;
            Inserir(usuario);
            return new ValidationResult();
        }
        catch (ValidationException ex)
        {
            return new ValidationResult(ex.Errors);
        }
        catch (Exception ex)
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Exception", ex.Message)
            };
            return new ValidationResult(failures);
        }
    }

    public void Editar(Usuario usuario)
    {
        var validacao = _validator.Validate(usuario);
        if (validacao.IsValid)
        {
            _usuarioRepositorio.Editar(usuario);
        }
        else
        {
            throw new Exception(validacao.Errors.FirstOrDefault().ToString());
        }
    }

    private int GerarId()
    {
        const int idInicial = 1;
        const int indiceVazio = 0;

        List<int> ListaIds = new();
        foreach (var usuario in _usuarioRepositorio.ObterTodos(null))
        {
            ListaIds.Add(usuario.IdUsuario);
        }

        if (ListaIds.Count() == indiceVazio) 
        { 
            return idInicial;
        }

        ListaIds.Sort();
        var indiceUltimo = ListaIds.Count() - idInicial;
        var idFinal = ListaIds[indiceUltimo] + idInicial;
        return idFinal;
    }

    public Usuario? AutenticarUsuario(Usuario usuario)
    {
        var caminhoDoArquivo = TokenServico.retorna();
        var mensagemUsuarioNaoEncontrado = "Usuario não encontrado!";

        var usuarioExistente = ObterTodos(null)
            .FirstOrDefault(u => u.NickName == usuario.NickName) 
            ?? throw new Exception(mensagemUsuarioNaoEncontrado);

        var comparacaoSenha = HashServico.Comparar(usuarioExistente.Senha, usuario.Senha);
        if (comparacaoSenha is true)
        {
            var lines = File.ReadAllLines(caminhoDoArquivo);
            foreach (var line in lines)
            {
                var validacao = TokenServico.VerificarValidadeToken(line, usuarioExistente);
                if (validacao) 
                { 
                    return usuarioExistente;
                }
            }
            
            var token = TokenServico.GerarToken(usuarioExistente);

            var file = File.AppendText(caminhoDoArquivo);
            file.WriteLine(token);
            file.Close();

            usuarioExistente.Hash = token;

            return usuarioExistente;
        }
        else return null;
    }

    public string ValidarNickName(string nick)
    {
        try
        {
            var mensagemNickEmUso = "Indisponível*";
            var mensagemNickValido = "Nickname valido!";

            var usuario = new Usuario()
            {
                Nome = "Usuario Teste",
                NickName = nick,
                Senha = "Abc12345",
                Plano = PlanoEnum.Free
            };

            var usuarioBuscar = ObterTodos(new FiltroUsuario()
            { 
                FiltroNome = nick
            })?
            .FirstOrDefault();

            if (usuarioBuscar is not null)
            {
                return mensagemNickEmUso;
            }

            _validator.ValidateAndThrow(usuario);
            return mensagemNickValido;
        }
        catch (ValidationException ex)
        {
            return ex.Errors.FirstOrDefault().ErrorMessage;
        }
    }
}