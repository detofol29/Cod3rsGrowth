using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Enumeradores;
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
    public class EnumController : ControllerBase
    {
        private readonly TodosEnumeradores servicoEnum;
        public EnumController()
        {
            servicoEnum = new TodosEnumeradores();
        }

        [HttpGet]
        public OkObjectResult ObterGeneros()
        {
            var generos = servicoEnum.ObterTodos<GeneroEnum>();
            return Ok(generos);
        }
        
        [HttpGet("filtros")]
        public OkObjectResult ObterFiltros()
        {
            FiltroFilme filtro = new();
            filtro.FiltroGenero = GeneroEnum.Terror;
            filtro.FiltroDisponivelNoPlano = false;
            return Ok(filtro);
        }
    }
}