using Agenda.DataTransfer.Turmas.Responses;
using Agenda.Dominio.Turmas.Entidades;
using AutoMapper;
using Libraries.Dominio.Consultas;

namespace Agenda.Aplicacao.Turmas.Profiles
{
    public class TurmaProfile : Profile
    {
        public TurmaProfile()
        {
            CreateMap<Turma, TurmaResponse>()
                .ForMember(dest => dest.Categoria, 
                    memb => memb.MapFrom(source => source.Categoria));
            CreateMap<PaginacaoConsulta<Turma>, PaginacaoConsulta<TurmaResponse>>();
        }
    }
}