using Agenda.DataTransfer.Instrutores.Responses;
using Agenda.Dominio.Instrutores.Entidades;
using Agenda.Dominio.Instrutores.Enumeradores;
using AutoMapper;
using Libraries.Comum.Enums;
using Libraries.Dominio.Consultas;

namespace Agenda.Aplicacao.Instrutores.Profiles
{
    public class InstrutoresProfile : Profile
    {
        public InstrutoresProfile()
        {
            CreateMap<Instrutor, InstrutorResponse>();
            CreateMap<PaginacaoConsulta<Instrutor>, PaginacaoConsulta<InstrutorResponse>>();
        }
    }
}