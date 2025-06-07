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
    public class NivelUrgenciaController : ControllerBase
    {
        private readonly NivelUrgenciaService _nivelUrgenciaService;

        public NivelUrgenciaController(NivelUrgenciaService nivelUrgenciaService)
        {
            _nivelUrgenciaService = nivelUrgenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelUrgencia>>> Get()
        {
            var niveisUrgencia = await _nivelUrgenciaService.GetAllNivelUrgenciaAsync();
            return Ok(niveisUrgencia);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NivelUrgencia>> Get(int id)
        {
            try
            {
                var nivelUrgencia = await _nivelUrgenciaService.GetNivelUrgenciaByIdAsync(id);
                if (nivelUrgencia == null)
                    return NotFound();
                return Ok(nivelUrgencia);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(NivelUrgencia nivelUrgencia)
        {
            try
            {
                await _nivelUrgenciaService.AddNivelUrgenciaAsync(nivelUrgencia);
                return CreatedAtAction(nameof(Get), new { id = nivelUrgencia.Id }, nivelUrgencia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, NivelUrgencia nivelUrgencia)
        {
            try
            {
                await _nivelUrgenciaService.UpdateNivelUrgenciaAsync(id, nivelUrgencia);
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
                await _nivelUrgenciaService.DeleteNivelUrgenciaAsync(id);
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
