using Agenda.Dominio.UsuariosAcesso.Entidades;
using Agenda.Dominio.UsuariosAcesso.Excecoes;
using Agenda.Dominio.UsuariosAcesso.Repositorios;
using Agenda.Dominio.UsuariosAcesso.Servicos.Interfaces;
using Libraries.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Dominio.UsuariosAcesso.Servicos
{
    public class UsuariosAcessoServico : IUsuariosAcessoServico
    {
        private readonly IUsuariosAcessoRepositorio usuariosAcessoRepositorio; 
       
        public UsuariosAcessoServico(IUsuariosAcessoRepositorio usuariosAcessoRepositorio)
        {
            this.usuariosAcessoRepositorio = usuariosAcessoRepositorio;
        }

        public SessaoAcesso Autenticar(string login, string senha)
        {
            var hashSenha = usuariosAcessoRepositorio.CriptografarSenhaAcesso(login, senha);
            UsuarioAcesso usuario = usuariosAcessoRepositorio.ListarTodos()
                .Where(x => x.Senha == hashSenha)
                .FirstOrDefault();

            if (usuario == null)
            {
                throw new AutenticacaoInvalidaExcecao();
            }

            var sessao = new SessaoAcesso()
            {
                Codigo = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };

            sessao.Token = usuariosAcessoRepositorio.GerarTokenJwt(sessao);
            return sessao;
        }

        public UsuarioAcesso Instanciar(string nome, string login, string email, string senha) 
        {
            UsuarioAcesso usuario = usuariosAcessoRepositorio.ListarTodos()
                .Where(
                    x => x.Email.ToLower() == email.ToLower() || 
                    x.Login.ToLower() == login.ToLower()
                ).FirstOrDefault();
            
            if (usuario != null)
            {
                throw new UsuarioCadastradoExcecao();
            }

            usuario = new UsuarioAcesso(nome, login.ToLower(), email.ToLower());
            var hash = usuariosAcessoRepositorio.CriptografarSenhaAcesso(usuario.Login, senha);
            
            usuario.SetSenha(hash);

            return usuario;
        }

        public UsuarioAcesso Validar(int id)
        {
            UsuarioAcesso usuario = usuariosAcessoRepositorio.PesquisarPor(id);

            if (usuario == null)
            {
                throw new RegraDeNegocioExcecao("Usuário não encontrado");
            }
            
            return usuario;
        }
    }
}