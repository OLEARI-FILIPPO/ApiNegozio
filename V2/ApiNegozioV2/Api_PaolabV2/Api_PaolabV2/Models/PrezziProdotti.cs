using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_PaolabV2.Models
{
    public partial class PrezziProdotti
    {
        public int Id { get; set; }
        public int IdProdotto { get; set; }
        public decimal Prezzo { get; set; }
        public string? Descrizione { get; set; }

        [ForeignKey("IdProdotto")]
        public virtual Prodotti IdProdottoNavigation { get; set; } = null!;
    }
}
