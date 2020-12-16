using AutoMapper;
using EVenda.Venda.Business.ViewModels;
using EVenda.Venda.Data.Models;

namespace EVenda.Venda.API.ConfigStartup
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
        }
    }
}
