using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using FluentValidation;
using FluentValidation.Results;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.web.Controllers;
using Cod3rsGrowth.Infra.Servicos;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Identity.Client;

namespace Cod3rsGrowth.Servicos.Servicos;

public class UsuarioServicos : IUsuarioRepositorio
{
    private readonly UsuarioRepositorio _usuarioRepositorio;
    private readonly IValidator<Usuario> _validator;
    public UsuarioServicos(UsuarioRepositorio usuarioRepositorio, IValidator<Usuario> validator)
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
            var senhaEncriptada = HashServico.GerarSenhaEncriptada(usuario.Senha);
            usuario.Senha = senhaEncriptada;
            Inserir(usuario);
            return new ValidationResult();
        }
        catch (ValidationException ex)
        {
            return new ValidationResult(ex.Errors);
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

        List<int> ListaIds = new List<int>();
        foreach (var usuario in _usuarioRepositorio.ObterTodos(null))
        {
            ListaIds.Add(usuario.IdUsuario);
        }
        if (ListaIds.Count() == indiceVazio) { return idInicial; }
        ListaIds.Sort();
        var indiceUltimo = ListaIds.Count() - idInicial;
        var idFinal = ListaIds[indiceUltimo] + idInicial;
        return idFinal;
    }

    public Usuario AutenticarUsuario(Usuario usuario)
    {


        var usuarioExistente = ObterTodos(null).FirstOrDefault(u => u.NickName == usuario.NickName) ?? throw new Exception("Usuario não encontrado!");
        //verificar se existe Token Ativo

        var comparacaoSenha = HashServico.Comparar(usuarioExistente.Senha, usuario.Senha);
        if (comparacaoSenha is true)
        {
            //Gerar Token
            var token = TokenServico.GerarToken(usuarioExistente);

            //Armazenar token no txt
            var filePath = TokenServico.retorna();
            var file = File.AppendText(filePath);
            file.WriteLine(token);
            file.Close();

            usuarioExistente.Hash = token;

            return usuarioExistente;
        }
        else return null;
    }
}