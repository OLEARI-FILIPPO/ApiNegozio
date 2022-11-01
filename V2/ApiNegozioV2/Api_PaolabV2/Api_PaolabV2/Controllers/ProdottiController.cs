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
    public class ProdottiController : ControllerBase
    {
        private readonly db_a8d5d1_negozioContext _context;
        private readonly IMapper mapper;

        public ProdottiController(db_a8d5d1_negozioContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }


        // GET: api/Prodotti
        [HttpGet]
        public  ActionResult<IEnumerable<Prodotti>> GetProdotti()
        {
            return Ok(_context.Prodotti.Select(s => mapper.Map<ProdottiDTO>(s)).ToList());
        }

        // GET: api/Prodotti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prodotti>> GetProdotti(int id)
        {
            var prodotti = await _context.Prodotti.FindAsync(id);

            if (prodotti == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProdottiDTO>(prodotti));
        }

        // PUT: api/Prodotti/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdotti(int id, ProdottiDTO prodotti)
        {
            if (id != prodotti.IdProdotto)
            {
                return BadRequest();
            }

            _context.Entry(mapper.Map<Prodotti>(prodotti)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdottiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Prodotti
        [HttpPost]
        public async Task<ActionResult<Prodotti>> PostProdotti(ProdottiDTO prodotti)
        {
            _context.Prodotti.Add(mapper.Map<Prodotti>(prodotti));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdotti", new { id = prodotti.IdProdotto }, prodotti);
        }

        // DELETE: api/Prodotti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdotti(int id)
        {
            var prodotti = await _context.Prodotti.FindAsync(id);
            if (prodotti == null)
            {
                return NotFound();
            }

            _context.Prodotti.Remove(prodotti);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProdottiExists(int id)
        {
            return _context.Prodotti.Any(e => e.IdProdotto == id);
        }

        #region Custom endpoints
        // GET: api/Prodotti/Fornitore/id
        [HttpGet("Fornitore/{id}")]
        public async Task<ActionResult<IEnumerable<Prodotti>>> GetProdottiFornitore(int id)
        {
            //tutti i prodotti di un fornitore
            if (!_context.Fornitori.Any(a => a.IdFornitore == id))
                return BadRequest();

            var prodotti = await _context.Prodotti.Where(w => w.IdFornitore == id).ToArrayAsync();

            if (prodotti == null)
            {
                return NotFound();
            }

            return Ok(prodotti.Select(s=> mapper.Map<ProdottiDTO>(s)));
        }


        #endregion
    }
}
