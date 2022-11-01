using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_PaolabV2.Models;
using System.Collections.Immutable;
using AutoMapper;
using Api_PaolabV2.ModelsDTO;

namespace Api_PaolabV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaglieController : ControllerBase
    {
        private readonly db_a8d5d1_negozioContext _context;
        private readonly IMapper mapper;

        public TaglieController(db_a8d5d1_negozioContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Taglie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taglie>>> GetTaglie()
        {
            var taglie = await _context.Taglie.ToListAsync();
            return Ok(taglie.Select(s=> mapper.Map<TaglieDTO>(s)));
        }

        // GET: api/Taglie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taglie>> GetTaglie(int id)
        {
            var taglie = await _context.Taglie.FindAsync(id);

            if (taglie == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TaglieDTO>(taglie));
        }

        // PUT: api/Taglie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaglie(int id, TaglieDTO taglie)
        {
            if (id != taglie.IdTaglia)
            {
                return BadRequest();
            }

            _context.Entry(mapper.Map<Taglie>(taglie)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaglieExists(id))
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

        // POST: api/Taglie
        [HttpPost]
        public async Task<ActionResult<Taglie>> PostTaglie(TaglieDTO taglie)
        {
            _context.Taglie.Add(mapper.Map<Taglie>(taglie));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaglie", new { id = taglie.IdTaglia }, taglie);
        }

        // DELETE: api/Taglie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaglie(int id)
        {
            var taglie = await _context.Taglie.FindAsync(id);
            if (taglie == null)
            {
                return NotFound();
            }

            _context.Taglie.Remove(taglie);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TaglieExists(int id)
        {
            return _context.Taglie.Any(e => e.IdTaglia == id);
        }

        #region Custom endpoints
        // GET: api/Taglie/Fornitore/id
        [HttpGet("Fornitore/{id}")]
        public ActionResult<IEnumerable<Taglie>> GetProdottiFornitore(int id)
        {
            //tutte le taglie di un fornitore
            if (!_context.Fornitori.Any(a => a.IdFornitore == id))
                return BadRequest();

            var taglie = _context.Taglie.Where(w => w.TaglieProdotti.Any(wr=>wr.IdProdottoNavigation.IdFornitore == id)).Distinct().ToList();
            if(taglie == null || taglie.Count == 0)
                return NotFound();

            return Ok(taglie.Select(s=> mapper.Map<TaglieDTO>(s)));
        }


        #endregion
    }
}
