using System;
using System.Collections.Generic;

namespace Api_PaolabV2.Models
{
    public partial class Taglie
    {
        public Taglie()
        {
            TaglieProdotti = new HashSet<TaglieProdotti>();
        }

        public int IdTaglia { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<TaglieProdotti> TaglieProdotti { get; set; }
    }
}
