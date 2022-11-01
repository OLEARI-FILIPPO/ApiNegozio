namespace ApiNegozio.Models
{
    public partial class Prodotto
    {
        public Prodotto()
        {
            //TaglieFornitori = new HashSet<TaglieFornitori>();
        }

        public int IdPrdt { get; set; }
        public string Nome { get; set; } = null!;
        public string? Categoria { get; set; }
        public byte Giacenza { get; set; }
        public string Descrizione { get; set; } = null!;
        public decimal Prezzo { get; set; }
        public bool Disponibile { get; set; }
        public string? ImgUrl { get; set; }

        //public virtual ICollection<TaglieFornitori> TaglieFornitori { get; set; }
    }
}
