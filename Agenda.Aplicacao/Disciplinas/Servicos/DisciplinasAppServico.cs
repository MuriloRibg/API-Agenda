using System;
using System.Collections.Generic;
using System.Linq;
using Agenda.Aplicacao.Disciplinas.Servicos.Interfaces;
using Agenda.DataTransfer.Disciplinas.Requests;
using Agenda.DataTransfer.Disciplinas.Responses;
using Agenda.Dominio.Disciplinas.Entidades;
using Agenda.Dominio.Disciplinas.Repositorios;
using Agenda.Dominio.Disciplinas.Servicos.Interfaces;
using AutoMapper;
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Dominio.Consultas;
using NHibernate.Mapping;

namespace Agenda.Aplicacao.Disciplinas.Servicos
{
    public class DisciplinasAppServico : IDisciplinasAppServico
    {
        private readonly IDisciplinasRepositorio disciplinasRepositorio;
        private readonly IDisciplinasServico disciplinasServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DisciplinasAppServico(IDisciplinasRepositorio disciplinasRepositorio,
            IDisciplinasServico disciplinasServico, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.disciplinasRepositorio = disciplinasRepositorio;
            this.disciplinasServico = disciplinasServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public DisciplinaResponse Recuperar(int id)
        {
            Disciplina disciplina = disciplinasRepositorio.Recuperar(id);
            DisciplinaResponse response = mapper.Map<DisciplinaResponse>(disciplina);
            return response;
        }

        public PaginacaoConsulta<DisciplinaResponse> Listar(DisciplinaListarRequest request)
        {
            var query = disciplinasRepositorio.Query();
            if (!string.IsNullOrWhiteSpace(request.Nome))
                query = query.Where(d => d.Nome.ToUpper().Contains(request.Nome.ToUpper()));
            if (!string.IsNullOrWhiteSpace(request.Pilar))
                query = query.Where(d => d.Pilar.ToUpper().Contains(request.Pilar.ToUpper()));
            
            PaginacaoConsulta<Disciplina> resultado = disciplinasRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

            var response = mapper.Map<PaginacaoConsulta<DisciplinaResponse>>(resultado);

            return response;
        }

        public DisciplinaResponse Inserir(DisciplinaInserirRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                Disciplina disciplina = new Disciplina(request.Nome, request.Pilar);
                disciplinasRepositorio.Inserir(disciplina);

                var response = mapper.Map<DisciplinaResponse>(disciplina);

                unitOfWork.Commit();

                return response;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public DisciplinaResponse Editar(int id, DisciplinaEditarRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                Disciplina disciplina = disciplinasServico.Validar(id);
                disciplina.SetNome(request.Nome);
                disciplina.SetPilar(request.Pilar);

                disciplinasRepositorio.Editar(disciplina);
                var response = mapper.Map<DisciplinaResponse>(disciplina);

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
                Disciplina disciplina = disciplinasServico.Validar(id);

                disciplina.SetDeleteAt(DateTime.Now);
                disciplinasRepositorio.Editar(disciplina);

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