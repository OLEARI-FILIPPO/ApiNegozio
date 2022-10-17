namespace ApiNegozio.Models
{
    public partial class Taglia
    {
        public Taglia()
        {
            //TaglieFornitori = new HashSet<TaglieFornitori>();
        }

        public int IdTaglia { get; set; }
        public string TagliaVestito { get; set; } = null!;

        //public virtual ICollection<TaglieFornitori> TaglieFornitori { get; set; }
    }
}
