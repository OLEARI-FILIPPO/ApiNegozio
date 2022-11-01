using System;
using System.Collections.Generic;

namespace Api_PaolabV2.Models
{
    public partial class MisureTaglie
    {
        public int IdMisura { get; set; }
        public int IdTaglia { get; set; }
        public int Misura { get; set; }
        public string? Descrizione { get; set; }

        public virtual TaglieProdotti IdTagliaNavigation { get; set; } = null!;
    }
}
