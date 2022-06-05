using Agenda.Dominio.Aulas.Entidades;
using Agenda.Dominio.Aulas.Repositorios;
using Agenda.Aplicacao.Aulas.Servicos.Interfaces;
using Agenda.DataTransfer.Aulas.Requests;
using AutoMapper;
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Dominio.Excecoes;
using Libraries.Dominio.Consultas;

namespace Agenda.Aplicacao.Aulas.Servicos
{
    public class AulaAppServico : IAulasAppServico
    {
        private readonly IAulaRepositorio aulaRepositorio;
        private readonly IMapper mapper;

        public AulaAppServico(IMapper mapper, IAulaRepositorio aulaRepositorio){
            this.mapper = mapper;
            this.aulaRepositorio = aulaRepositorio;
        }

        public PaginacaoConsulta<Aula> Listar(AulaListarRequest request){

            var query = aulaRepositorio.Query();

            PaginacaoConsulta<Aula> aulas = aulaRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
            
            return aulas;
        }
    }
}
