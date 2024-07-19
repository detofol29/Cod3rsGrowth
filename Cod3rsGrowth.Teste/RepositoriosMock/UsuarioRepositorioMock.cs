using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Dominio.Interfaces;
using Xunit.Sdk;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servicos.Servicos;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Cod3rsGrowth.Servicos.Validacoes;
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
            var alterarUsuario = ObterPorId(usuario.IdUsuario);
            alterarUsuario.Nome = usuario.Nome;
            alterarUsuario.FilmesDoUsuario = usuario.FilmesDoUsuario;
            alterarUsuario.Plano = usuario.Plano;
            alterarUsuario.Senha = usuario.Senha;
            alterarUsuario.NickName = usuario.NickName;
            var validacao = _validator.Validate(alterarUsuario);
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
            //var usuarioVerificar = ObterTodos(new FiltroUsuario() { FiltroNome = usuario.NickName })?.FirstOrDefault();

            //if (usuarioVerificar is not null)
            //{
            //    throw new Exception("Esse NickName já está em uso!");
            //}

            _validator.ValidateAndThrow(usuario);
            //var senhaEncriptada = HashServico.GerarSenhaEncriptada(usuario.Senha);
            //usuario.Senha = senhaEncriptada;
            Inserir(usuario);
            return new ValidationResult();
        }
        catch (ValidationException ex)
        {
            return new ValidationResult(ex.Errors);
        }
    }
}