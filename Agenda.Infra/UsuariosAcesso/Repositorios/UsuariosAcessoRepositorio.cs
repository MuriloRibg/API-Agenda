using Agenda.Dominio.UsuariosAcesso.Entidades;
using Agenda.Dominio.UsuariosAcesso.Repositorios;
using Libraries.NHibernate.Repositorios;
using Libraries.Util.Criptografias;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Agenda.Infra.UsuariosAcesso.Repositorios
{
    public class UsuariosAcessoRepositorio : RepositorioNHibernate<UsuarioAcesso>, IUsuariosAcessoRepositorio
    {
        private IConfiguration configuration;

        public UsuariosAcessoRepositorio(ISession session, IConfiguration configuration) : base(session)
        {
            this.configuration = configuration;
        }

        public string CriptografarSenhaAcesso(string login, string senha)
        {
            var hash = CriptografiaMD5.Criptografar(senha + "." + login);

            return hash;
        }

        public string GerarTokenJwt(SessaoAcesso sessao)
        {
            string secret = configuration.GetSection("Jwt:Secret").Value;
            string id = sessao.Codigo.ToString();

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, id)
            };

            DateTime dataCriacao = DateTime.Now.AddMinutes(-5);
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromHours(8);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var handler = new JwtSecurityTokenHandler();
            var securityToken = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims),
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            };

            return handler.WriteToken(handler.CreateToken(securityToken));
        }
    }
}