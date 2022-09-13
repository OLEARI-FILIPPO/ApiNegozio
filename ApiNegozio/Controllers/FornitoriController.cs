using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiNegozio.Models;

namespace ApiNegozio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornitoriController : ControllerBase
    {
        private readonly ProdottiNegozioContext _model;
        public FornitoriController(ProdottiNegozioContext model)
        {
            _model = model;
        }

        // GET: api/Fornitori
        [HttpGet]
        public ActionResult GetFornitori()
        {
            List<Fornitore> fornitori = _model.Fornitori.ToList();
            if (fornitori == null) { return NotFound("Nessun record fornitore trovato."); }

            return Ok(fornitori);
        }

        // GET: api/Fornitori/5
        [HttpGet("{id}")]
        public ActionResult GetFornitore(int id)
        {
            var fornitore = _model.Fornitori.FirstOrDefault(f => f.IdFrntr.Equals(id));
            if (fornitore == null) { return NotFound("Nessun Fornitore trovato."); }

            return Ok(fornitore);
        }

        // PUT: api/Fornitori/5
        [HttpPut("{id}")]
        public ActionResult PutFornitore(int id, [FromBody] Fornitore fornitore)
        {
            var record = _model.Fornitori.FirstOrDefault(f => f.IdFrntr.Equals(id));
            if (record == null) return NotFound();

            record.Nome = fornitore.Nome;
            _model.SaveChanges();
            return Ok("Record aggiornato con successo");
        }

        // POST: api/Fornitori
        [HttpPost]
        public ActionResult PostFornitore(Fornitore fornitore)
        {
            _model.Fornitori.Add(fornitore);
            _model.SaveChanges();
            return Ok("Record aggiunto con successo");
        }

        // DELETE: api/Fornitori/5
        [HttpDelete("{id}")]
        public ActionResult DeleteFornitore(int id)
        {
            var record = _model.Fornitori.FirstOrDefault(f => f.IdFrntr.Equals(id));
            if (record == null) return NotFound("Impossibile eliminare, non trovato");

            _model.Remove(record);
            _model.SaveChanges();
            return Ok("Record eliminato con successo");
        }
    }
}
