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
    public class RegiaoController : ControllerBase
    {
        private readonly RegiaoService _regiaoService;

        public RegiaoController(RegiaoService regiaoService)
        {
            _regiaoService = regiaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Regiao>>> Get()
        {
            var regioes = await _regiaoService.GetAllRegiaoAsync();
            return Ok(regioes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Regiao>> Get(int id)
        {
            try
            {
                var regiao = await _regiaoService.GetRegiaoByIdAsync(id);
                if (regiao == null)
                    return NotFound();
                return Ok(regiao);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Regiao regiao)
        {
            try
            {
                await _regiaoService.AddRegiaoAsync(regiao);
                return CreatedAtAction(nameof(Get), new { id = regiao.Id }, regiao);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Regiao regiao)
        {
            try
            {
                await _regiaoService.UpdateRegiaoAsync(id, regiao);
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
                await _regiaoService.DeleteRegiaoAsync(id);
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
