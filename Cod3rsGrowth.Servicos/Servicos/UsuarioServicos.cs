using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using FluentValidation;
using FluentValidation.Results;

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
    
    public List<Usuario> ObterTodos()
    {
        return _usuarioRepositorio.ObterTodos();
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
        usuario.MinhaLista.Add(filme);
    }

    public void Logar(string nick, string senha)
    {
    }

    public void Deslogar(Usuario usuario)
    {
    }

    public void LicenciarFilmePorUsuario(Usuario usuario)
    {
    }

    public void Remover(int id)
    {
        _usuarioRepositorio.Remover(id);
    }

    public ValidationResult CriarUsuario(Usuario usuario)
    {
        try
        {
            usuario.IdUsuario = GerarId();
            _validator.ValidateAndThrow(usuario);
            Inserir(usuario);
            return new ValidationResult();
        }
        catch (ValidationException ex)
        {
            return new ValidationResult(ex.Errors);
        }
    }

    public void Editar(int id, Usuario usuario)
    {
        var validacao = _validator.Validate(usuario);
        if (validacao.IsValid)
        {
            _usuarioRepositorio.Editar(id, usuario);
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

        List<int> ListaIds = new List<int>();
        foreach (var usuario in _usuarioRepositorio.ObterTodos())
        {
            ListaIds.Add(usuario.IdUsuario);
        }
        if (ListaIds.Count() == indiceVazio) { return idInicial; }
        ListaIds.Sort();
        var indiceUltimo = ListaIds.Count() - idInicial;
        var idFinal = ListaIds[indiceUltimo] + idInicial;
        return idFinal;
    }
}