using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using ValidationException = FluentValidation.ValidationException;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Cod3rsGrowth.Dominio.Filtros;

namespace Cod3rsGrowth.Servicos.Servicos;

public class FilmeServicos : IFilmeRepositorio
{
    private readonly IValidator<Filme> _validator;
    private readonly IFilmeRepositorio _filmeRepositorio;
    public FilmeServicos(IFilmeRepositorio filmeRepositorio, IValidator<Filme> validator)
    {
        _filmeRepositorio = filmeRepositorio;
        _validator = validator;
    }

    public List<Filme> ObterTodos(FiltroFilme? filtroFilme)
    {
        return _filmeRepositorio.ObterTodos(filtroFilme);
    }

    public Filme ObterPorId(int id)
    {
        return _filmeRepositorio.ObterPorId(id);
    }

    public void Inserir(Filme filme)
    {
        _filmeRepositorio.Inserir(filme);
    }

    public void Remover(int id)
    {
        _filmeRepositorio.Remover(id);
    }

    public List<Ator> ObterAtoresDoFilme(Filme filme)
    {
        return filme.Atores;
    }

    public static bool VerificarDisponibilidadeDoFilme(Usuario usuario, Filme filme)
    {
        switch (usuario.Plano)
        {
            case PlanoEnum.Premium:
                return true;
            case PlanoEnum.Nerd when filme.Genero == GeneroEnum.Ficcao || filme.Genero == GeneroEnum.Fantasia:
                return true;
            case PlanoEnum.Kids when filme.Classificacao == ClassificacaoIndicativa.livre:
                return true;
            case PlanoEnum.Free when filme.Genero == GeneroEnum.Comedia:
                return true;
            default:
                return false;
        }
    }

    public ValidationResult CriarFilme(Filme filme)
    {
        try
        {
            filme.Id = GerarId();
            _validator.ValidateAndThrow(filme);
            Inserir(filme);
            return new ValidationResult();
        }
        catch (ValidationException ex)
        {
            return new ValidationResult(ex.Errors);
        } 
    }

    public void Editar(int id, Filme filme)
    {
        var validacao = _validator.Validate(filme);
        if (validacao.IsValid)
        {
            _filmeRepositorio.Editar(id, filme);
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
        var listaFilmes = _filmeRepositorio.ObterTodos(null);
        foreach (var filme in listaFilmes)
        {
            ListaIds.Add(filme.Id);
        }
        if (ListaIds.Count() == indiceVazio) { return idInicial; }
        ListaIds.Sort();
        var indiceUltimo = ListaIds.Count() - idInicial;
        var idFinal = ListaIds[indiceUltimo] + idInicial;
        return idFinal;
    }
}