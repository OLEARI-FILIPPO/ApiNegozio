using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_PaolabV2.Models
{
    public partial class Prodotti
    {
        public Prodotti()
        {
            PrezziProdotti = new HashSet<PrezziProdotti>();
            TaglieProdotti = new HashSet<TaglieProdotti>();
        }

        public int IdProdotto { get; set; }
        public int IdFornitore { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descrizione { get; set; }
        public string? Categoria { get; set; }
        public int? Giacenza { get; set; }
        public int? Sconto { get; set; }
        public bool? Disponibile { get; set; }
        public string? ImgUrl { get; set; }

        [ForeignKey("IdFornitore")]
        public virtual Fornitori IdFornitoreNavigation { get; set; } = null!;
        public virtual ICollection<PrezziProdotti> PrezziProdotti { get; set; }
        public virtual ICollection<TaglieProdotti> TaglieProdotti { get; set; }
    }
}
