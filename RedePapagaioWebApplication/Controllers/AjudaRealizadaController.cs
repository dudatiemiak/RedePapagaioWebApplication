using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Exceptions;
using RedePapagaioWebApplication.Models;
using RedePapagaioWebApplication.Services;

namespace RedePapagaioWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AjudaRealizadaController : ControllerBase
    {
        private readonly AjudaRealizadaService _ajudaRealizadaService;

        public AjudaRealizadaController(AjudaRealizadaService ajudaRealizadaService)
        {
            _ajudaRealizadaService = ajudaRealizadaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AjudaRealizada>>> Get()
        {
            var ajudasRealizadas = await _ajudaRealizadaService.GetAllAjudaRealizadaAsync();
            return Ok(ajudasRealizadas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AjudaRealizada>> Get(int id)
        {
            try
            {
                var ajudaRealizada = await _ajudaRealizadaService.GetAjudaRealizadaByIdAsync(id);
                if (ajudaRealizada == null)
                    return NotFound();
                return Ok(ajudaRealizada);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AjudaRealizada ajudaRealizada)
        {
            try
            {
                await _ajudaRealizadaService.AddAjudaRealizadaAsync(ajudaRealizada);
                return CreatedAtAction(nameof(Get), new { id = ajudaRealizada.Id }, ajudaRealizada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AjudaRealizada ajudaRealizada)
        {
            try
            {
                await _ajudaRealizadaService.UpdateAjudaRealizadaAsync(id, ajudaRealizada);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _ajudaRealizadaService.DeleteAjudaRealizadaAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { StatusCode = 404, Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<AjudaRealizada>>> GetByUsuarioId(int usuarioId)
        {
            var ajudas = await _ajudaRealizadaService.GetAjudaRealizadaByUsuarioIdAsync(usuarioId);
            return Ok(ajudas);
        }

        [HttpGet("ocorrencia/{ocorrenciaId}")]
        public async Task<ActionResult<IEnumerable<AjudaRealizada>>> GetByOcorrenciaId(int ocorrenciaId)
        {
            var ajudas = await _ajudaRealizadaService.GetAjudaRealizadaByOcorrenciaIdAsync(ocorrenciaId);
            return Ok(ajudas);
        }
    }
}
