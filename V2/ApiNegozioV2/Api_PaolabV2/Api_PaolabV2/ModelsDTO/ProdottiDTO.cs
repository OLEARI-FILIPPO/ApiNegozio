namespace Api_PaolabV2.ModelsDTO
{
    public class ProdottiDTO
    {
        public int IdProdotto { get; set; }
        public int IdFornitore { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descrizione { get; set; }
        public string? Categoria { get; set; }
        public int? Giacenza { get; set; }
        public int? Sconto { get; set; }
        public bool? Disponibile { get; set; }
        public string? ImgUrl { get; set; }
    }
}
