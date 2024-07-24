using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
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
        return ator.Premios ?? throw new Exception("Lista de [Prêmios] vazia");
    }

    public List<Ator> ObterTodos(FiltroAtor? filtroAtor)
    {
        return _atorRepositorio.ObterTodos(filtroAtor);
    }

    public Ator ObterPorId(int id)
    {
        return _atorRepositorio.ObterPorId(id);
    }

    public void Inserir(Ator ator)
    {
        _atorRepositorio.Inserir(ator);
    }

    public void Remover(int id)
    {
        _atorRepositorio.Remover(id);
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

    public void Editar(Ator ator)
    {
        var validacao = _validator.Validate(ator);
        if (validacao.IsValid)
        {
            _atorRepositorio.Editar(ator);
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
        foreach (var ator in _atorRepositorio.ObterTodos(null))
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