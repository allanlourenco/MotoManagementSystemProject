using AutoMapper;
using MotoManagementSystemProject.Domain.DTOs;
using MotoManagementSystemProject.Domain.Entities;

namespace MotoManagementSystemProject.CrossCuting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile() 
        {
            CreateMap<Moto, MotoDTO>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<Entregador, EntregadorDTO>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Data_Nascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Numero_CNH, opt => opt.MapFrom(src => src.NumeroCNH))
                .ForMember(dest => dest.Tipo_CNH, opt => opt.MapFrom(src => src.TipoCNH))
                .ForMember(dest => dest.Imagem_CNH, opt => opt.MapFrom(src => src.ImagemCNH)).ReverseMap();
            CreateMap<Locacao, LocacaoDTO>()
                .ForMember(dest => dest.Data_Previsao_Termino, opt => opt.MapFrom(src => src.DataPrevisaoTermino))
                .ForMember(dest => dest.Data_Termino, opt => opt.MapFrom(src => src.DataTermino))
                .ForMember(dest => dest.Data_Inicio, opt => opt.MapFrom(src => src.DataInicio))
                .ForMember(dest => dest.Entregador_Id, opt => opt.MapFrom(src => src.EntregadorId))
                .ForMember(dest => dest.Moto_Id, opt => opt.MapFrom(src => src.MotoId))
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Plano, opt => opt.MapFrom(src => src.TipoPlano)).ReverseMap();
            CreateMap<Locacao, ConsultaLocacaoDTO>()
                .ForMember(dest => dest.Data_Previsao_Termino, opt => opt.MapFrom(src => src.DataPrevisaoTermino))
                .ForMember(dest => dest.Data_Termino, opt => opt.MapFrom(src => src.DataTermino))
                .ForMember(dest => dest.Data_Inicio, opt => opt.MapFrom(src => src.DataInicio))
                .ForMember(dest => dest.Entregador_Id, opt => opt.MapFrom(src => src.EntregadorId))
                .ForMember(dest => dest.Moto_Id, opt => opt.MapFrom(src => src.MotoId))
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Plano, opt => opt.MapFrom(src => src.TipoPlano))
                .ForMember(dest => dest.Data_Devolucao, opt => opt.MapFrom(src => src.DataDevolucao)).ReverseMap();
        }
        
    }
}