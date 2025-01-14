using Agenda.Aplicacao.UsuariosAcesso.Servicos.Interfaces;
using Agenda.DataTransfer.UsuariosAcesso.Requests;
using Agenda.DataTransfer.UsuariosAcesso.Responses;
using Agenda.Dominio.UsuariosAcesso.Entidades;
using Agenda.Dominio.UsuariosAcesso.Repositorios;
using Agenda.Dominio.UsuariosAcesso.Servicos.Interfaces;
using AutoMapper;
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Dominio.Excecoes;

namespace Agenda.Aplicacao.UsuariosAcesso.Servicos
{
    public class UsuariosAcessoAppServico : IUsuariosAcessoAppServico
    {
        
        private readonly IMapper mapper; 
        private readonly IUsuariosAcessoServico usuariosAcessoServico;
        private readonly IUsuariosAcessoRepositorio usuariosAcessoRepositorio;
        private readonly IUnitOfWork unitOfWork;

        public UsuariosAcessoAppServico(
            IMapper mapper,
            IUsuariosAcessoServico usuariosAcessoServico,
            IUsuariosAcessoRepositorio usuariosAcessoRepositorio,
            IUnitOfWork unitOfWork
        ) 
        {
            this.mapper = mapper;
            this.usuariosAcessoServico = usuariosAcessoServico;
            this.usuariosAcessoRepositorio = usuariosAcessoRepositorio;
            this.unitOfWork = unitOfWork;
        }

        public UsuarioAcessoResponse Cadastrar(UsuarioAcessoRequest request)
        {
            try 
            {
                unitOfWork.BeginTransaction();

                UsuarioAcesso usuarioAcesso = usuariosAcessoServico.Instanciar(
                    request.Nome,
                    request.Login,
                    request.Email,
                    request.Senha
                );

                usuariosAcessoRepositorio.Inserir(usuarioAcesso);

                var response = mapper.Map<UsuarioAcessoResponse>(usuarioAcesso);

                unitOfWork.Commit();

                return response;
                
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public UsuarioAcessoSessaoResponse Autenticar(UsuarioAcessoAutenticacaoRequest request)
        {
            if (request == null)
            {
                throw new RegraDeNegocioExcecao("Requisição inválida!");
            }

            try
            {
                unitOfWork.BeginTransaction();

                var sessao = usuariosAcessoServico.Autenticar(request.Login, request.Senha);

                unitOfWork.Commit();

                var response = new UsuarioAcessoSessaoResponse()
                {
                    Codigo = sessao.Codigo,
                    Nome = sessao.Nome,
                    Jwt = sessao.Token,
                    Email = sessao.Email
                };

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