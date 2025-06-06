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
    public class TipoAjudaController : ControllerBase
    {
        private readonly TipoAjudaService _tipoAjudaService;

        public TipoAjudaController(TipoAjudaService tipoAjudaService)
        {
            _tipoAjudaService = tipoAjudaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAjuda>>> Get()
        {
            var tiposAjuda = await _tipoAjudaService.GetAllTipoAjudaAsync();
            return Ok(tiposAjuda);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAjuda>> Get(int id)
        {
            try
            {
                var tipoAjuda = await _tipoAjudaService.GetTipoAjudaByIdAsync(id);
                if (tipoAjuda == null)
                    return NotFound();
                return Ok(tipoAjuda);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoAjuda tipoAjuda)
        {
            try
            {
                await _tipoAjudaService.AddTipoAjudaAsync(tipoAjuda);
                return CreatedAtAction(nameof(Get), new { id = tipoAjuda.Id }, tipoAjuda);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoAjuda tipoAjuda)
        {
            try
            {
                await _tipoAjudaService.UpdateTipoAjudaAsync(id, tipoAjuda);
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
                await _tipoAjudaService.DeleteTipoAjudaAsync(id);
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
