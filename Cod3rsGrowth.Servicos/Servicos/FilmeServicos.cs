using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Diagnostics;
using System.Text;
using System.Threading.Tasks.Dataflow;
using ValidationException = FluentValidation.ValidationException;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Cod3rsGrowth.Servicos.Servicos;

public class FilmeServicos : IFilmeRepositorio
{
    private readonly IValidator<Filme> _validator;
    private readonly IFilmeRepositorio _filmeRepositorio;
    private readonly IAtorRepositorio _atorRepositorio;
    public FilmeServicos(IFilmeRepositorio filmeRepositorio, IValidator<Filme> validator, IAtorRepositorio atorRepositorio)
    {
        _filmeRepositorio = filmeRepositorio;
        _atorRepositorio = atorRepositorio;
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
        FiltroAtor filtro = new() { FiltroIdFilme = filme.Id };
        return _atorRepositorio.ObterTodos(filtro);
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

    public void CriarFilme (Filme filme)
    {
        var filmeVerificar = ObterTodos(null)
                .Where(f => f.Titulo == filme.Titulo)
                .Select(f => f)
                .FirstOrDefault();

        if (filmeVerificar is not null)
        {
            throw new Exception("Esse Filme já existe!");
        }

        filme.Id = GerarId();
        _validator.ValidateAndThrow(filme);
        Inserir(filme);
    }

    public void Editar(Filme filme)
    {
        var validacao = _validator.Validate(filme);
        if (validacao.IsValid)
        {
            _filmeRepositorio.Editar(filme);
        }
        else
        {
            var erros = new StringBuilder();
            foreach (var erro in validacao.Errors)
            {
                erros.AppendLine(erro.ErrorMessage);
            }
            throw new Exception(erros.ToString());
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