using System;
using System.Linq;
using Agenda.Aplicacao.Turmas.Servicos.Interfaces;
using Agenda.DataTransfer.Turmas.Requests;
using Agenda.DataTransfer.Turmas.Responses;
using Agenda.Dominio.Categorias.Entidades;
using Agenda.Dominio.Categorias.Servicos.Interfaces;
using Agenda.Dominio.Turmas.Entidades;
using Agenda.Dominio.Turmas.Repositorios;
using Agenda.Dominio.Turmas.Servicos.Interfaces;
using AutoMapper;
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Dominio.Consultas;
using Libraries.Util.Extensoes;

namespace Agenda.Aplicacao.Turmas.Servicos
{
    public class TurmaAppServico : ITurmasAppServico
    {
        private readonly ITurmasServico turmasServico;
        private readonly ITurmasRepositorio turmasRepositorio;
        private readonly ICategoriaServico categoriaServico; 
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public TurmaAppServico(ITurmasServico turmasServico, ITurmasRepositorio turmasRepositorio, IMapper mapper, IUnitOfWork unitOfWork, ICategoriaServico categoriaServico)
        {
            this.turmasServico = turmasServico;
            this.turmasRepositorio = turmasRepositorio;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.categoriaServico = categoriaServico;
        }

        public TurmaResponse Recuperar(int id)
        {
            Turma disciplina = turmasRepositorio.Recuperar(id);
            TurmaResponse response = mapper.Map<TurmaResponse>(disciplina);
            return response;
        }

        public PaginacaoConsulta<TurmaResponse> Listar(TurmaListarRequest request)
        {
            var query = turmasRepositorio.Query();
            if (!string.IsNullOrWhiteSpace(request.Nome))
                query = query.Where(t => t.Nome.ToUpper().Contains(request.Nome));
            if (request.QuantidadeAlunos > 0)
                query = query.Where(t => t.QuantidadeAlunos >= request.QuantidadeAlunos);
            if (request.IdCategoria > 0)
                query = query.Where(t => t.Categoria.Id == request.IdCategoria);
            
            PaginacaoConsulta<Turma> resultado =
                turmasRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
            var response = mapper.Map<PaginacaoConsulta<TurmaResponse>>(resultado);
            return response;
        }

        public TurmaResponse Inserir(TurmaInserirRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Categoria categoria = categoriaServico.Validar(request.IdCategoria);
                Turma turma = new Turma(request.Nome, request.QuantidadeAlunos, categoria);
                turmasRepositorio.Inserir(turma);

                var response = mapper.Map<TurmaResponse>(turma);
                unitOfWork.Commit();

                return response;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public TurmaResponse Editar(int id, TurmaEditarRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Turma turma = turmasServico.Validar(id);
                turma.SetNome(request.Nome);
                turma.SetQuantidadeAlunos(request.QuantidadeAlunos);
                turma.SetCategoria(categoriaServico.Validar(request.IdCategoria));
                
                turmasRepositorio.Editar(turma);
                var response = mapper.Map<TurmaResponse>(turma);
                    
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
                Turma turma = turmasServico.Validar(id);
                turma.SetDeleteAt(DateTime.Now);
                turmasRepositorio.Editar(turma);
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