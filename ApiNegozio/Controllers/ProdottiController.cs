using ApiNegozio.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiNegozio.Controllers
{
    [Route("api/prodotti")]
    [ApiController]
    public class ProdottiController : ControllerBase
    {
        private readonly ProdottiNegozioContext _model;
        public ProdottiController(ProdottiNegozioContext model)
        {
            _model = model;
        }

        // GET: prendo tutti i prodotti
        [HttpGet]
        public ActionResult GetAll(int id)
        {
            List<Prodotto> prodotti = _model.Prodotti.ToList();
            if (prodotti == null) return NotFound("Nessun prodotto trovato");

            return Ok(prodotti);
        }

        // GET: prendo un singolo prodotto
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var prodotto = _model.Prodotti.FirstOrDefault(f => f.IdPrdt.Equals(id));
            if (prodotto == null) return NotFound("Podotto non trovato");

            return Ok(prodotto);
        }

        // POST: inserimento nuovo prodotto
        [HttpPost]
        public ActionResult Post([FromBody] Prodotto nuovoProdotto)
        {
            var verificaPresente = _model.Prodotti.FirstOrDefault(f => f.Nome.Equals(nuovoProdotto.Nome)
                                                                        && f.ImgUrl.Equals(nuovoProdotto.ImgUrl));
            if(verificaPresente != null) { return Problem("Un prodotto con lo stesso nome e immagine è già stato inserito, cambia nome o immagine"); }

            _model.Prodotti.Add(nuovoProdotto);
            _model.SaveChanges();
            return Ok("Prodotto inserito correttamente.");
        }

        // PUT: modifica di un prodotto
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Prodotto prodottoDaModificare)
        {
            Prodotto presente = _model.Prodotti.FirstOrDefault(f => f.IdPrdt.Equals(id));
            if(presente == null) { return NotFound("Prodotto non presente, non posso modificarlo."); }

            presente.Nome = prodottoDaModificare.Nome;
            presente.Categoria = prodottoDaModificare.Categoria;
            presente.Giacenza = prodottoDaModificare.Giacenza;
            presente.Descrizione = prodottoDaModificare.Descrizione;
            presente.Prezzo = prodottoDaModificare.Prezzo;
            presente.Disponibile = prodottoDaModificare.Disponibile;
            presente.ImgUrl = prodottoDaModificare.ImgUrl;


            _model.SaveChanges();
            return Ok("Prodotto modificato correttamente.");
        }

        // DELETE: eliminazione di un prodotto
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var presente = _model.Prodotti.FirstOrDefault(f => f.IdPrdt.Equals(id));
            if(presente == null) { return NotFound("Prodotto non presente, non posso eliminarlo."); }

            _model.Remove(presente);
            _model.SaveChanges();
            return Ok("Prodotto eliminato correttamente.");
        }
    }
}
