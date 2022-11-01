using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_PaolabV2.Models;
using AutoMapper;
using Api_PaolabV2.ModelsDTO;

namespace Api_PaolabV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornitoriController : ControllerBase
    {
        private readonly db_a8d5d1_negozioContext _context;
        private readonly IMapper mapper;

        public FornitoriController(db_a8d5d1_negozioContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Fornitori
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornitori>>> GetFornitori()
        {
            var fornitori = await _context.Fornitori.ToListAsync();
            return Ok(fornitori.Select(s=> mapper.Map<FornitoriDTO>(s)));
        }

        // GET: api/Fornitori/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fornitori>> GetFornitori(int id)
        {
            var fornitori = await _context.Fornitori.FindAsync(id);

            if (fornitori == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<FornitoriDTO>(fornitori));
        }

        // PUT: api/Fornitori/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornitori(int id, FornitoriDTO fornitori)
        {
            if (id != fornitori.IdFornitore)
            {
                return BadRequest();
            }

            _context.Entry(mapper.Map<Fornitori>(fornitori)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornitoriExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fornitori
        [HttpPost]
        public async Task<ActionResult<Fornitori>> PostFornitori(FornitoriDTO fornitori)
        {
            _context.Fornitori.Add(mapper.Map<Fornitori>(fornitori));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornitori", new { id = fornitori.IdFornitore }, fornitori);
        }

        // DELETE: api/Fornitori/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornitori(int id)
        {
            var fornitori = await _context.Fornitori.FindAsync(id);
            if (fornitori == null)
            {
                return NotFound();
            }

            _context.Fornitori.Remove(fornitori);
            await _context.SaveChangesAsync();

            return Ok("Fornitore eliminato con successo!");
        }

        private bool FornitoriExists(int id)
        {
            return _context.Fornitori.Any(e => e.IdFornitore == id);
        }
    }
}
