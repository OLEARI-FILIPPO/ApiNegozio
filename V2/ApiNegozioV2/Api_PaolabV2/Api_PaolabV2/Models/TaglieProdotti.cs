using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_PaolabV2.Models
{
    public partial class TaglieProdotti
    {
        public TaglieProdotti()
        {
            MisureTaglie = new HashSet<MisureTaglie>();
        }

        public int Id { get; set; }
        public int IdProdotto { get; set; }
        public int IdTaglia { get; set; }

        [ForeignKey("IdProdotto")]
        public virtual Prodotti IdProdottoNavigation { get; set; } = null!;
        [ForeignKey("IdTaglia")]
        public virtual Taglie IdTagliaNavigation { get; set; } = null!;
        public virtual ICollection<MisureTaglie> MisureTaglie { get; set; }
    }
}
