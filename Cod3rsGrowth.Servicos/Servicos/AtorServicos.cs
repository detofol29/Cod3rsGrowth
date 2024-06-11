using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using FluentValidation;
using FluentValidation.Results;

namespace Cod3rsGrowth.Servicos.Servicos;

public class AtorServicos : IAtorRepositorio
{
    private readonly IValidator<Ator> _validator;
    private readonly IAtorRepositorio _atorRepositorio;
    public AtorServicos(IAtorRepositorio atorRepositorio, IValidator<Ator> validator)
    {
        _atorRepositorio = atorRepositorio;
        _validator = validator;
    }
    public List<string> ObterPremiosDoAtor(Ator ator)
    {
        return ator.Premios;
    }

    public List<Ator> ObterTodos()
    {
        return _atorRepositorio.ObterTodos();
    }

    public Ator ObterPorId(int id)
    {
        return _atorRepositorio.ObterPorId(id);
    }

    public void Inserir(Ator ator)
    {
        _atorRepositorio.Inserir(ator);
    }

    public ValidationResult CriarAtor(Ator ator)
    {
        try
        {
            ator.Id = GerarId();
            _validator.ValidateAndThrow(ator);
            Inserir(ator);
            return new ValidationResult();
        }
        catch(ValidationException ex)
        {
            return new ValidationResult(ex.Errors);
        }
    }

    private int GerarId()
    {
        const int idInicial = 1;
        const int indiceVazio = 0;

        List<int> ListaIds = new List<int>();
        foreach (var ator in _atorRepositorio.ObterTodos())
        {
            ListaIds.Add(ator.Id);
        }
        if (ListaIds.Count() == indiceVazio) { return idInicial; }
        ListaIds.Sort();
        var indiceUltimo = ListaIds.Count() - idInicial;
        var idFinal = ListaIds[indiceUltimo] + idInicial;
        return idFinal;
    }
}