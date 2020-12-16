using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVenda.Estoque.API.ConfigStartup
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {

            CreateMap<ProdutoViewModel, Produto>().ReverseMap();

        }
    }
}
