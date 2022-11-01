using System;
using System.Collections.Generic;

namespace Api_PaolabV2.Models
{
    public partial class Fornitori
    {
        public Fornitori()
        {
            Prodotti = new HashSet<Prodotti>();
        }

        public int IdFornitore { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descrizione { get; set; }

        public virtual ICollection<Prodotti> Prodotti { get; set; }
    }
}
