using AutoMapper;
using EVenda.Estoque.Business.Models;
using EVenda.Estoque.Data.Models;

namespace EVenda.Estoque.API.ConfigStartup
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
        }
    }
}
