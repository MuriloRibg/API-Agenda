using System;
using System.Collections.Generic;
using System.Linq;
using Agenda.Aplicacao.Instrutores.Servicos.Interfaces;
using Agenda.DataTransfer.Instrutores.Requests;
using Agenda.DataTransfer.Instrutores.Responses;
using Agenda.Dominio.Instrutores.Entidades;
using Agenda.Dominio.Instrutores.Repositorios;
using Agenda.Dominio.Instrutores.Servicos.Interfaces;
using AutoMapper;
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Dominio.Excecoes;

namespace Agenda.Aplicacao.Instrutores.Servicos
{
    public class InstrutorAppServico : IInstrutorAppServico
    {
        private readonly IMapper mapper; 
        private readonly IInstrutorServico instrutorServico;
        private readonly IInstrutoresRepositorio instrutorRepositorio;
        private readonly IUnitOfWork unitOfWork;

        public InstrutorAppServico(
            IMapper mapper,
            IInstrutorServico instrutorServico, 
            IInstrutoresRepositorio instrutorRepositorio,
            IUnitOfWork unitOfWork
        ) 
        {
            this.mapper = mapper;
            this.instrutorServico = instrutorServico;
            this.instrutorRepositorio = instrutorRepositorio;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<InstrutorResponse> Listar()
        {
            var query = instrutorRepositorio.ListarTodos();

            List<Instrutor> resultado = query.ToList();

            var response = mapper.Map<List<InstrutorResponse>>(resultado);

            return response;
        }

        public InstrutorResponse Recuperar(int id)
        {
            var instrutor = instrutorServico.Validar(id);
            var response = mapper.Map<InstrutorResponse>(instrutor);
            return response;
        }

        public InstrutorResponse Inserir(InstrutorRequest request) 
        {
            try 
            {
                unitOfWork.BeginTransaction();

                var instrutor = new Instrutor(
                    request.Nome, 
                    request.Abreviacao, 
                    request.Email, 
                    request.Disponibilidade, 
                    request.Pilar
                );

                instrutorRepositorio.Adicionar(instrutor);

                var response = mapper.Map<InstrutorResponse>(instrutor);

                unitOfWork.Commit();

                return response;
                
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public InstrutorResponse Atualizar (int id, InstrutorRequest request) 
        {
            try
            {
                unitOfWork.BeginTransaction();
                
                Instrutor instrutor = instrutorServico.Atualizar(
                    id, 
                    request.Nome,
                    request.Abreviacao,
                    request.Email,
                    request.Disponibilidade,
                    request.Pilar
                );

                instrutorRepositorio.Editar(instrutor);

                var response = mapper.Map<InstrutorResponse>(instrutor);

                unitOfWork.Commit();

                return response;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public InstrutorResponse Deletar(int id)
        {
            try
            {
                unitOfWork.BeginTransaction();

                Instrutor instrutor = instrutorRepositorio.PesquisarPor(id);

                if (instrutor == null)
                {
                    throw new RegraDeNegocioExcecao("Instrutor não encontrado!");
                }

                instrutor.SetData(DateTime.Now);

                unitOfWork.Commit();

                var response = mapper.Map<InstrutorResponse>(instrutor);

                return response;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}