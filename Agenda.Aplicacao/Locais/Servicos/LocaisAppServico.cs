using System;
using System.Linq;
using Agenda.Aplicacao.Locais.Servicos.Interfaces;
using Agenda.DataTransfer.Locais.Requests;
using Agenda.DataTransfer.Locais.Responses;
using Agenda.Dominio.Locais.Entidades;
using Agenda.Dominio.Locais.Repositorios;
using Agenda.Dominio.Locais.Servicos.Interfaces;
using AutoMapper;
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Dominio.Consultas;
using Libraries.Util.Extensoes;

namespace Agenda.Aplicacao.Locais.Servicos
{
    public class LocaisAppServico : ILocaisAppServico
    {
        private readonly ILocaisRepositorio locaisRepositorio;
        private readonly ILocaisServico locaisServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public LocaisAppServico(ILocaisRepositorio locaisRepositorio, ILocaisServico locaisServico, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.locaisRepositorio = locaisRepositorio;
            this.locaisServico = locaisServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public LocalResponse Recuperar(int id)
        {
            Local local = locaisRepositorio.Recuperar(id);
            LocalResponse response = mapper.Map<LocalResponse>(local);
            return response;
        }

        public PaginacaoConsulta<LocalResponse> Listar(LocalListarRequest request)
        {
            var query = locaisRepositorio.Query();
            if (!string.IsNullOrWhiteSpace(request.Nome))
                query = query.Where(l => l.Nome.ToUpper().Contains(request.Nome.ToUpper()));
            if (request.Capacidade > 0)
                query = query.Where(l => l.Capacidade == request.Capacidade);
            if (request.Sistemas.IsNull())
                query = query.Where(l => l.Sistemas == request.Sistemas);

            PaginacaoConsulta<Local> resultado =
                locaisRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

            var response = mapper.Map<PaginacaoConsulta<LocalResponse>>(resultado);

            return response;
        }

        public LocalResponse Inserir(LocalInserirRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                Local local = new Local(request.Nome, request.Capacidade, request.Sistemas);
                locaisRepositorio.Inserir(local);

                var response = mapper.Map<LocalResponse>(local);

                unitOfWork.Commit();
                return response;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public LocalResponse Editar(int id, LocalEditarRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                Local local = locaisServico.Validar(id);
                local.SetNome(request.Nome);
                local.SetCapacidade(request.Capacidade);
                local.SetSistemas(request.Sistemas);

                locaisRepositorio.Editar(local);
                var response = mapper.Map<LocalResponse>(local);

                unitOfWork.Commit();
                return response;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Local local = locaisServico.Validar(id);

                local.SetDeleteAt(DateTime.Now);
                locaisRepositorio.Editar(local);

                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}