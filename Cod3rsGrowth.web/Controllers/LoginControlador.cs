using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Infra.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.web.Controllers;

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
        // Recupera o usuário
        var usuario = repositorio.ObterTodos(null).FirstOrDefault(u => u.NickName == modelo.NickName);

        // Verifica se o usuário existe
        if (usuario == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        // Gera o Token
        var token = TokenServico.GerarToken(usuario);

        // Oculta a senha
        usuario.Senha = "";

        // Retorna os dados
        //return new OkObjectResult(usuario);

        return new
        {
            user = usuario, 
            token = token
        };
    }
}