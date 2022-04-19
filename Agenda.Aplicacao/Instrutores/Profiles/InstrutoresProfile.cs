using Agenda.DataTransfer.Instrutores.Responses;
using Agenda.Dominio.Instrutores.Entidades;
using AutoMapper;

namespace Agenda.Aplicacao.Instrutores.Profiles
{
    public class InstrutoresProfile : Profile
    {
        public InstrutoresProfile()
        {
            CreateMap<Instrutor, InstrutorResponse>();
        }
    }
}