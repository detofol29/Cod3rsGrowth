using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Cod3rsGrowth.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeServicos servico;
        public FilmeController(FilmeServicos _servico)
        {
            servico = _servico;
        }

        [HttpPost]
        public CreatedResult Adicionar([FromBody] Filme filme)
        {
            servico.CriarFilme(filme);
            return Created(filme.Id.ToString(), filme);
        }

        [HttpDelete("{id}")]
        public NoContentResult Remover([FromRoute] int id)
        {
            servico.Remover(id);
            return NoContent();
        }

        [HttpPatch]
        public NoContentResult Editar([FromBody] Filme filme)
        {
            servico.Editar(filme);
            return NoContent();
        }

        [HttpGet]
        public OkObjectResult ObterTodos([FromQuery] FiltroFilme? filtro)
        {
            var filmes = servico.ObterTodos(filtro);
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public OkObjectResult ObterPorId([FromRoute] int id)
        {
            var filme = servico.ObterPorId(id);
            return Ok(filme);
        }
    }
}