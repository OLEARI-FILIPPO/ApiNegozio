using ApiNegozio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiNegozio.Controllers
{
    [Route("api/[controller]")]
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
            var prodotto = _model.Prodotti.FirstOrDefault(f => f.IdPrdt == id);
            if (prodotto == null) return NotFound("Podotto non trovato");

            return Ok(prodotto);
        }

        // GET: prendo tutti i prodotti di un certo fornitore
        // api/prodotti/{nome}
        [HttpGet("/api/prodottiFornitore/{id}")]
        public ActionResult GetAllProducts(int id)
        {
            Fornitore fornitore = _model.Fornitori.FirstOrDefault(f => f.IdFrntr == id);
            if (fornitore == null) { return NotFound("fornitore non trovato."); }

            List<TaglieFornitori> taglieFornitori = _model.TaglieFornitori.Where(w => w.IdFrntr == id).ToList();
            if (taglieFornitori == null) return NotFound();


            List<Prodotto> prodotti = new List<Prodotto>();

            foreach (var item in taglieFornitori)
            {
                if (_model.Prodotti.Any(a => a.IdPrdt == item.IdPrdt))
                {
                    Prodotto prod = _model.Prodotti.FirstOrDefault(f => f.IdPrdt == item.IdPrdt);
                    prodotti.Add(prod);
                }
            }

            return Ok(prodotti);
        }

        // POST: inserimento nuovo prodotto
        [HttpPost]
        public ActionResult Post([FromBody] Prodotto nuovoProdotto)
        {
            var verificaPresente = _model.Prodotti.FirstOrDefault(f => f.Nome == nuovoProdotto.Nome
                                                                        && f.ImgUrl == nuovoProdotto.ImgUrl);
            if(verificaPresente != null) { return Problem("Un prodotto con lo stesso nome e immagine è già stato inserito, cambia nome o immagine"); }

            _model.Prodotti.Add(nuovoProdotto);
            _model.SaveChanges();
            return Ok("Prodotto inserito correttamente.");
        }

        // PUT: modifica di un prodotto
        // api/prodotti/3
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Prodotto prodottoDaModificare)
        {
            Prodotto presente = _model.Prodotti.FirstOrDefault(f => f.IdPrdt == id);
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
        // api/prodotti/44
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var presente = _model.Prodotti.FirstOrDefault(f => f.IdPrdt == id);
            if(presente == null) { return NotFound("Prodotto non presente, non posso eliminarlo."); }

            _model.Remove(presente);
            _model.SaveChanges();
            return Ok("Prodotto eliminato correttamente.");
        }
    }
}
