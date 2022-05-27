using Agenda.DataTransfer.Disciplinas.Responses;
using Agenda.Dominio.Disciplinas.Entidades;
using AutoMapper;

namespace Agenda.Aplicacao.Disciplinas.Profiles
{
    public class DisciplinasProfile : Profile
    {
        public DisciplinasProfile()
        {
            CreateMap<Disciplina, DisciplinaResponse>();
        }
    }
}