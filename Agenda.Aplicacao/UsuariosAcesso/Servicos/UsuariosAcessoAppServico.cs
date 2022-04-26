using Agenda.Aplicacao.UsuariosAcesso.Servicos.Interfaces;
using Agenda.DataTransfer.UsuariosAcesso.Requests;
using Agenda.DataTransfer.UsuariosAcesso.Responses;
using Agenda.Dominio.UsuariosAcesso.Entidades;
using Agenda.Dominio.UsuariosAcesso.Repositorios;
using Agenda.Dominio.UsuariosAcesso.Servicos.Interfaces;
using AutoMapper;
using Libraries.Aplicacao.Transacoes.Interfaces;

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

        public UsuarioAcessoResponse Inserir(UsuarioAcessoRequest request)
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

                usuariosAcessoRepositorio.Adicionar(usuarioAcesso);

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
    }
}