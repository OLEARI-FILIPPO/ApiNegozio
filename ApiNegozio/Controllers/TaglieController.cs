using Microsoft.AspNetCore.Mvc;
using ApiNegozio.Models;

namespace ApiNegozio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaglieController : ControllerBase
    {
        private readonly ProdottiNegozioContext _model;
        public TaglieController(ProdottiNegozioContext model)
        {
            _model = model;
        }

        // GET: api/Taglie
        [HttpGet]
        public ActionResult GetTaglia()
        {
            List<Taglia> taglie = _model.Taglia.ToList();
            if (taglie == null) { return NotFound("Nessun record taglia trovato."); }

            return Ok(taglie);
        }

        // GET: api/Taglie/5
        [HttpGet("{id}")]
        public ActionResult GetTaglia(int id)
        {
            var taglie = _model.Taglia.FirstOrDefault(f => f.IdTaglia.Equals(id));
            if (taglie == null) { return NotFound("Nessuna taglia trovata."); }

            return Ok(taglie);
        }

        // PUT: api/Taglie/5
        [HttpPut("{id}")]
        public ActionResult PutTaglia(int id, Taglia taglia)
        {
            var record = _model.Taglia.FirstOrDefault(f => f.IdTaglia.Equals(id));
            if (record == null) return NotFound();

            record.TagliaVestito = taglia.TagliaVestito;
            _model.SaveChanges();
            return Ok("Record aggiornato con successo");
        }

        // POST: api/Taglie
        [HttpPost]
        public ActionResult PostTaglia(Taglia taglia)
        {
            _model.Taglia.Add(taglia);
            _model.SaveChanges();
            return Ok("Record aggiunto con successo");
        }

        // DELETE: api/Taglie/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTaglia(int id)
        {
            var record = _model.Taglia.FirstOrDefault(f => f.IdTaglia.Equals(id));
            if (record == null) return NotFound("Impossibile eliminare, non trovato");
                
            _model.Remove(record);
            _model.SaveChanges();
            return Ok("Record eliminato con successo");
        }
    }
}
