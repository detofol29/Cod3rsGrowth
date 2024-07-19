using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Validacoes;
using Cod3rsGrowth.Teste.ClassesSingleton;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using FluentValidation.Results;

namespace Cod3rsGrowth.Teste.RepositoriosMock;

public class UsuarioRepositorioMock : IUsuarioRepositorio
{
    private readonly List<Usuario> tabelasSingleton;
    private readonly IValidator<Usuario> _validator;
    public UsuarioRepositorioMock()
    {
        tabelasSingleton = TabelasSingleton.ObterInstanciaUsuarios;
        _validator = new UsuarioValidacao();
    }

    public Usuario ObterPorId(int id)
    {
        try
        {
            return tabelasSingleton.FirstOrDefault(a => a.IdUsuario == id) ?? throw new Exception("Usuario nao encontrado");
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Inserir(Usuario usuario)
    {
        tabelasSingleton.Add(usuario);
    }

    public List<Usuario> ObterTodos(FiltroUsuario? filtroUsuario)
    {
        IQueryable<Usuario> query = tabelasSingleton.AsQueryable();

        if (filtroUsuario?.FiltroPlano != null)
        {
            query = from a in query
                    where a.Plano == filtroUsuario.FiltroPlano
                    select a;
        }
        return query.ToList();
    }

    public void Remover(int id)
    {
        try
        {
            var usuario = ObterPorId(id);
            tabelasSingleton.Remove(usuario);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Editar(Usuario usuario)
    {
        try
        {
<<<<<<< HEAD
            var alterarUsuario = ObterPorId(usuario.IdUsuario);
            alterarUsuario.Nome = usuario.Nome;
            alterarUsuario.FilmesDoUsuario = usuario.FilmesDoUsuario;
            alterarUsuario.Plano = usuario.Plano;
            alterarUsuario.Senha = usuario.Senha;
            alterarUsuario.NickName = usuario.NickName;
            var validacao = _validator.Validate(alterarUsuario);
=======
            var validacao = _validator.Validate(usuario);
            if (validacao.IsValid)
            {
                var alterarUsuario = ObterPorId(usuario.IdUsuario);
                alterarUsuario.Nome = usuario.Nome;
                alterarUsuario.FilmesDoUsuario = usuario.FilmesDoUsuario;
                alterarUsuario.Plano = usuario.Plano;
                alterarUsuario.Senha = usuario.Senha;
                alterarUsuario.NickName = usuario.NickName;
            }
            else
            {
                throw new Exception(validacao.Errors.First().ErrorMessage);
            }
            
>>>>>>> 6a69124b200c43d5fbe45e971739e8f9dffe4d5e
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public ValidationResult CriarUsuario(Usuario usuario)
    {
        try
        {
<<<<<<< HEAD
            //var usuarioVerificar = ObterTodos(new FiltroUsuario() { FiltroNome = usuario.NickName })?.FirstOrDefault();

            //if (usuarioVerificar is not null)
            //{
            //    throw new Exception("Esse NickName já está em uso!");
            //}

=======
>>>>>>> 6a69124b200c43d5fbe45e971739e8f9dffe4d5e
            _validator.ValidateAndThrow(usuario);
            usuario.IdUsuario = GerarId();
            Inserir(usuario);
            return new ValidationResult();
        }
        catch (ValidationException ex)
        {
            return new ValidationResult(ex.Errors);
        }
    }

    private int GerarId()
    {
        const int idInicial = 1;
        const int indiceVazio = 0;

        List<int> ListaIds = new();
        foreach (var usuario in ObterTodos(null))
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