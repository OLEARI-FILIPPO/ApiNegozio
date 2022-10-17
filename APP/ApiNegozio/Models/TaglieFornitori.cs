namespace ApiNegozio.Models
{
    public partial class TaglieFornitori
    {
        public int IdTglFr { get; set; }
        public int IdFrntr { get; set; }
        public int IdTaglia { get; set; }
        public int IdPrdt { get; set; }

        //public virtual Fornitore IdFrntrNavigation { get; set; } = null!;
        //public virtual Prodotto IdPrdtNavigation { get; set; } = null!;
        //public virtual Taglia IdTagliaNavigation { get; set; } = null!;
    }
}
