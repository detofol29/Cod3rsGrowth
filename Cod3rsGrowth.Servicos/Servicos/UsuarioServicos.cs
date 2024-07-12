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
using System.IdentityModel.Tokens.Jwt;
using System.Drawing;
using Microsoft.IdentityModel.Tokens;
using Cod3rsGrowth.Servicos.Validacoes;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;
using ValidationException = FluentValidation.ValidationException;

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

    public Filme LicenciarFilmePorUsuario(Usuario usuario, Filme filme)
    {
        if(usuario.Plano == PlanoEnum.Premium)
        {
            filme.DisponivelNoPlano = true;
            return filme;
        }
        else if (usuario.Plano == PlanoEnum.Kids && filme.Classificacao == ClassificacaoIndicativa.livre)
        {
            filme.DisponivelNoPlano = true;
            return filme;
        }
        else if(usuario.Plano == PlanoEnum.Nerd && (filme.Genero == GeneroEnum.Ficcao || filme.Genero == GeneroEnum.Fantasia))
        {
            filme.DisponivelNoPlano = true;
            return filme;
        }
        else
        {
            filme.DisponivelNoPlano = false;
            return filme;
        }
    }

    public void Remover(int id)
    {
        _usuarioRepositorio.Remover(id);
    }

    public ValidationResult CriarUsuario(Usuario usuario)
    {
        try
        {
            var usuarioVerificar = ObterTodos(new FiltroUsuario() { FiltroNome = usuario.NickName })?.FirstOrDefault();

            if (usuarioVerificar is not null)
            {
                throw new Exception("Esse NickName já está em uso!");
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
        var caminhoDoArquivo = TokenServico.retorna();

        //Obtem o usuario existente
        var usuarioExistente = ObterTodos(null).FirstOrDefault(u => u.NickName == usuario.NickName) ?? throw new Exception("Usuario não encontrado!");

        var comparacaoSenha = HashServico.Comparar(usuarioExistente.Senha, usuario.Senha);
        if (comparacaoSenha is true)
        {
            //verificar se existe Token Ativo
            var lines = File.ReadAllLines(caminhoDoArquivo);
            foreach (var line in lines)
            {
                var validacao = TokenServico.VerificarValidadeToken(line, usuarioExistente);
                if (validacao == true) { return usuarioExistente; }
            }
            
            //Gerar Token
            var token = TokenServico.GerarToken(usuarioExistente);

            //Armazenar token no txt
            var file = File.AppendText(caminhoDoArquivo);
            file.WriteLine(token);
            file.Close();

            usuarioExistente.Hash = token;

            return usuarioExistente;
        }
        else return null;
    }

}