using APPLICATION.UseCases;
using DOMAIN.Entities;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadosController : ControllerBase
    {
        private readonly ChamadoService _chamadoService;

        public ChamadosController(ChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarChamado(
            [FromBody] CriarChamadoRequest request)
        {
            var chamado = new Chamado(
                request.UsuarioId,
                request.Titulo,
                request.Descricao,
                request.Prioridade
            );

            var resultado = await _chamadoService.CreateChamadoAsync(chamado);

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var chamado = await _chamadoService.GetChamadoByIdAsync(id);

            if (chamado == null)
                return NotFound();

            return Ok(chamado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var chamados = await _chamadoService.GetAllChamadosAsync();
            return Ok(chamados);
        }
    }
}