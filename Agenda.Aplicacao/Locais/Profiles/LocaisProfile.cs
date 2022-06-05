using Agenda.DataTransfer.Locais.Responses;
using Agenda.Dominio.Locais.Entidades;
using AutoMapper;
using Libraries.Dominio.Consultas;

namespace Agenda.Aplicacao.Locais.Profiles
{
    public class LocaisProfile : Profile
    {
        public LocaisProfile()
        {
            CreateMap<Local, LocalResponse>();
            CreateMap<PaginacaoConsulta<Local>, PaginacaoConsulta<LocalResponse>>();
        }   
    }
}