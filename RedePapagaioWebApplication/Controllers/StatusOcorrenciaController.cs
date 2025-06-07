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
    public class StatusOcorrenciaController : ControllerBase
    {
        private readonly StatusOcorrenciaService _statusOcorrenciaService;

        public StatusOcorrenciaController(StatusOcorrenciaService statusOcorrenciaService)
        {
            _statusOcorrenciaService = statusOcorrenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusOcorrencia>>> Get()
        {
            var statusOcorrencias = await _statusOcorrenciaService.GetAllStatusOcorrenciaAsync();
            return Ok(statusOcorrencias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusOcorrencia>> Get(int id)
        {
            try
            {
                var statusOcorrencia = await _statusOcorrenciaService.GetStatusOcorrenciaByIdAsync(id);
                if (statusOcorrencia == null) return NotFound();
                return Ok(statusOcorrencia);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(StatusOcorrencia statusOcorrencia)
        {
            try
            {
                await _statusOcorrenciaService.AddStatusOcorrenciaAsync(statusOcorrencia);
                return CreatedAtAction(nameof(Get), new { id = statusOcorrencia.Id }, statusOcorrencia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, StatusOcorrencia statusOcorrencia)
        {
            try
            {
                await _statusOcorrenciaService.UpdateStatusOcorrenciaAsync(id, statusOcorrencia);
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
                await _statusOcorrenciaService.DeleteStatusOcorrenciaAsync(id);
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
