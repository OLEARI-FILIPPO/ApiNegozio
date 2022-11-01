namespace ApiNegozio.Models
{
    public partial class Fornitore
    {
        public Fornitore()
        {
            //TaglieFornitori = new HashSet<TaglieFornitori>();
        }

        public int IdFrntr { get; set; }
        public string Nome { get; set; } = null!;

        //public virtual ICollection<TaglieFornitori> TaglieFornitori { get; set; }
    }
}
