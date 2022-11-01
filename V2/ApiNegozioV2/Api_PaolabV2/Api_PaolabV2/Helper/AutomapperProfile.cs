using Api_PaolabV2.Models;
using Api_PaolabV2.ModelsDTO;
using AutoMapper;

namespace Api_PaolabV2.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Prodotti, ProdottiDTO>().ReverseMap();
            CreateMap<Taglie, TaglieDTO>().ReverseMap();
            CreateMap<Fornitori, FornitoriDTO>().ReverseMap();
        }
    }
}
