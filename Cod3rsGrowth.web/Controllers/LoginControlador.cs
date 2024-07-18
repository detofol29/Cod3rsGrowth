using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Infra.Servicos;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Autenticador([FromBody] Usuario modelo)
    {
        var usuario = repositorio.ObterTodos(null).FirstOrDefault(u => u.NickName == modelo.NickName);

        if (usuario == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        var token = TokenServico.GerarToken(usuario);

        usuario.Senha = "";

        usuario.Hash = token;

        return new OkObjectResult(usuario);
    }
}