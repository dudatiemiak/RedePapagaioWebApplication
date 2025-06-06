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
    public class TipoOcorrenciaController : ControllerBase
    {
        private readonly TipoOcorrenciaService _tipoOcorrenciaService;

        public TipoOcorrenciaController(TipoOcorrenciaService tipoOcorrenciaService)
        {
            _tipoOcorrenciaService = tipoOcorrenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoOcorrencia>>> Get()
        {
            var tiposOcorrencia = await _tipoOcorrenciaService.GetAllTipoOcorrenciaAsync();
            return Ok(tiposOcorrencia);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoOcorrencia>> Get(int id)
        {
            try
            {
                var tipoOcorrencia = await _tipoOcorrenciaService.GetTipoOcorrenciaByIdAsync(id);
                if (tipoOcorrencia == null)
                    return NotFound();
                return Ok(tipoOcorrencia);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoOcorrencia tipoOcorrencia)
        {
            try
            {
                await _tipoOcorrenciaService.AddTipoOcorrenciaAsync(tipoOcorrencia);
                return CreatedAtAction(nameof(Get), new { id = tipoOcorrencia.Id }, tipoOcorrencia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoOcorrencia tipoOcorrencia)
        {
            try
            {
                await _tipoOcorrenciaService.UpdateTipoOcorrenciaAsync(id, tipoOcorrencia);
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
                await _tipoOcorrenciaService.DeleteTipoOcorrenciaAsync(id);
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
    }
}
