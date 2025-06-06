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
    public class TelefoneController : ControllerBase
    {
        private readonly TelefoneService _telefoneService;

        public TelefoneController(TelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefone>>> Get()
        {
            var telefones = await _telefoneService.GetAllTelefoneAsync();
            return Ok(telefones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Telefone>> Get(int id)
        {
            try
            {
                var telefone = await _telefoneService.GetTelefoneByIdAsync(id);
                if (telefone == null)
                    return NotFound();
                return Ok(telefone);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Telefone telefone)
        {
            try
            {
                await _telefoneService.AddTelefoneAsync(telefone);
                return CreatedAtAction(nameof(Get), new { id = telefone.Id }, telefone);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Telefone telefone)
        {
            try
            {
                await _telefoneService.UpdateTelefoneAsync(id, telefone);
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
                await _telefoneService.DeleteTelefoneAsync(id);
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
        public async Task<ActionResult<IEnumerable<Telefone>>> GetByUsuarioId(int usuarioId)
        {
            var telefones = await _telefoneService.GetTelefoneByUsuarioIdAsync(usuarioId);
            return Ok(telefones);
        }
    }
}
