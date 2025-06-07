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
    public class OcorrenciaController : ControllerBase
    {
        private readonly OcorrenciaService _ocorrenciaService;

        public OcorrenciaController(OcorrenciaService ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ocorrencia>>> Get()
        {
            var ocorrencias = await _ocorrenciaService.GetAllOcorrenciaAsync();
            return Ok(ocorrencias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ocorrencia>> Get(int id)
        {
            try
            {
                var ocorrencia = await _ocorrenciaService.GetOcorrenciaByIdAsync(id);
                if (ocorrencia == null)
                    return NotFound();
                return Ok(ocorrencia);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ocorrencia ocorrencia)
        {
            try
            {
                await _ocorrenciaService.AddOcorrenciaAsync(ocorrencia);
                return CreatedAtAction(nameof(Get), new { id = ocorrencia.Id }, ocorrencia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Ocorrencia ocorrencia)
        {
            try
            {
                await _ocorrenciaService.UpdateOcorrenciaAsync(id, ocorrencia);
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
                await _ocorrenciaService.DeleteOcorrenciaAsync(id);
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

        [HttpGet("status/{statusOcorrenciaId}")]
        public async Task<ActionResult<IEnumerable<Ocorrencia>>> GetByStatusOcorrenciaId(int statusOcorrenciaId)
        {
            var ocorrencias = await _ocorrenciaService.GetOcorrenciaByStatusOcorrenciaIdAsync(statusOcorrenciaId);
            return Ok(ocorrencias);
        }

        [HttpGet("nivel/{nivelUrgenciaId}")]
        public async Task<ActionResult<IEnumerable<Ocorrencia>>> GetByNivelUrgenciaId(int nivelUrgenciaId)
        {
            var ocorrencias = await _ocorrenciaService.GetOcorrenciaByNivelUrgenciaIdAsync(nivelUrgenciaId);
            return Ok(ocorrencias);
        }

        [HttpGet("tipo/{tipoOcorrenciaId}")]
        public async Task<ActionResult<IEnumerable<Ocorrencia>>> GetByTipoOcorrenciaId(int tipoOcorrenciaId)
        {
            var ocorrencias = await _ocorrenciaService.GetOcorrenciaByTipoOcorrenciaIdAsync(tipoOcorrenciaId);
            return Ok(ocorrencias);
        }
    }
}
