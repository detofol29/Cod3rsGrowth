using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cod3rsGrowth.web.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class FilmeControlador : ControllerBase
    {
        private readonly IFilmeRepositorio servico;
        private readonly FilmeValidacao validacao;
        public FilmeControlador(IFilmeRepositorio _servico, FilmeValidacao _validacao)
        {
            servico = _servico;
            validacao = _validacao;
        }

        [HttpPost]
        [Route("Adicionar")]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            if (filme is null)
            {
                return BadRequest();
            }
            var resultadoValidacao = validacao.Validate(filme);

            if (resultadoValidacao.IsValid)
            {
                servico.Inserir(filme);
                return Created(filme.Id.ToString(), filme);
            }

            return BadRequest("Filme invalido!");
        }

        [HttpDelete]
        [Route("Excluir")]
        public IActionResult ExcluirFilme([FromBody] int id)
        {
            servico.Remover(id);
            return Ok();
        }

        [HttpPatch]
        [Route("Atualizar")]
        public IActionResult EditarFilme([FromBody] Filme filme)
        {
            if (filme is null)
            {
                return BadRequest();
            }
            var resultadoValidacao = validacao.Validate(filme);

            if (resultadoValidacao.IsValid)
            {
                servico.Editar(filme);
                return Ok();
            }

            return BadRequest("Filme invalido!");
        }

        [HttpGet]
        [Route("ObterTodos")]
        public OkObjectResult ObterTodos()
        {
            var filmes = servico.ObterTodos(null);
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