using Microsoft.AspNetCore.Mvc;
using ApiNegozio.Models;

namespace ApiNegozio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaglieFornitoriController : ControllerBase
    {
        private readonly ProdottiNegozioContext _model;
        public TaglieFornitoriController(ProdottiNegozioContext model)
        {
            _model = model;
        }

        /*
         * Inserisco fornitore
         * inserisco una taglia
         * Creo il record taglie fornitori
         * 
         * e creo tanti record quante sono le taglie per ogni fornitore
         * 
         * */

        // GET: api/TaglieFornitori
        [HttpGet]
        public ActionResult GetTaglieFornitori()
        {
            List<TaglieFornitori> taglieFornitori = _model.TaglieFornitori.ToList();
            if(taglieFornitori == null) { return NotFound("Nessun record trovato."); }

            return Ok(taglieFornitori);
        }

        // GET: api/TaglieFornitori/5
        /*[HttpGet("{id}")]
        public ActionResult GetTaglieFornitori(int id)
        {
            var taglieFornitori = _model.TaglieFornitori.FirstOrDefault(f=>f.IdTglFr == id);
            if (taglieFornitori == null) { return NotFound("Nessun record trovato."); }

            return Ok(taglieFornitori);
        }*/

        

        // GET: prendo tutte le taglie di un certo fornitore
        // api/TaglieFornitori/{id}
        [HttpGet("{id}")]
        public ActionResult GetAllSizes(int id)
        {
            Fornitore fornitore = _model.Fornitori.FirstOrDefault(f => f.IdFrntr == id);
            if (fornitore == null) { return NotFound("fornitore non trovato."); }

            List<TaglieFornitori> taglieFornitore = _model.TaglieFornitori.Where(f => f.IdFrntr == fornitore.IdFrntr).ToList();
            if (taglieFornitore == null) { return NotFound("Nessuna taglia per questo fornitore."); }

            List<Taglia> taglie = new List<Taglia>();
            foreach (var item in taglieFornitore)
            {
                Taglia check = _model.Taglia.FirstOrDefault(w => w.IdTaglia == item.IdTaglia);
                if(check == null) { return NotFound("Taglia inesistente."); }
                taglie.Add(check);
            }

            return Ok(taglie);
        }

        // PUT: api/TaglieFornitori/5
        [HttpPut("{id}")]
        public ActionResult PutTaglieFornitori(int id, [FromBody]TaglieFornitori taglieFornitori)
        {
            if (id != taglieFornitori.IdTglFr) return BadRequest();

            var record = _model.TaglieFornitori.FirstOrDefault(f => f.IdTglFr == id);
            if (record == null) return NotFound();

            record.IdFrntr = taglieFornitori.IdFrntr;
            record.IdTaglia = taglieFornitori.IdTaglia;
            record.IdPrdt = taglieFornitori.IdPrdt;

            _model.SaveChanges();
            return Ok("Record aggiornato con successo");

        }

        // POST: api/TaglieFornitori
        [HttpPost]
        public ActionResult PostTaglieFornitori(TaglieFornitori taglieFornitori)
        {
            _model.TaglieFornitori.Add(taglieFornitori);
            _model.SaveChanges();
            return Ok("Record aggiunto con successo");
        }

        // DELETE: api/TaglieFornitori/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTaglieFornitori(int id)
        {
            var record = _model.TaglieFornitori.FirstOrDefault(f => f.IdTglFr == id);
            if (record == null) return NotFound("Impossibile eliminare, non trovato");

            _model.Remove(record);
            _model.SaveChanges();
            return Ok("Record eliminato con successo");
        }

    }
}
