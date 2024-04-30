using AutoMapper;
using Facens.Api.ViewModels;
using Facens.Business.Models;

namespace Facens.Api.Configurations
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<Cidadao, CidadaoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<SolicitacaoViewModel, Solicitacao>();
            CreateMap<Solicitacao, SolicitacaoViewModel>()
                .ForMember(dest => dest.NomeCidadao, opt => opt.MapFrom(src => src.Cidadao.Nome))
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.Descricao));

        }
    }
}
