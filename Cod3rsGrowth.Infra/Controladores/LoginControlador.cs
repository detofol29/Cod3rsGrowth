using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Infra.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra.Controladores;

[ApiController]
[Route("v1")]
public class LoginControlador : ControllerBase
{
    private UsuarioRepositorio repositorio;
    public LoginControlador(UsuarioRepositorio _repositorio)
    {
        repositorio = _repositorio;
    }
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> Autenticador([FromBody] Usuario modelo)
    {
        //Recuperar o usuário do repositório
        var usuario = repositorio.ObterTodos(null).FirstOrDefault(x => x.NickName == modelo.NickName);
        if(usuario == null) { return NotFound(new { message = "Usuário ou senha inválidos" }); }

        //gerar Token
        var token = TokenServico.GerarToken(usuario);

        //Ocultar senha
        usuario.Senha = "";

        //retoena os dados
        return new
        {
            user = usuario,
            token = token
        };
    }
}