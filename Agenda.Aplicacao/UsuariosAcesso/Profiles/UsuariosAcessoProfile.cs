using Agenda.DataTransfer.UsuariosAcesso.Responses;
using Agenda.Dominio.UsuariosAcesso.Entidades;
using AutoMapper;

namespace Agenda.Aplicacao.UsuariosAcesso.Profiles
{
    public class UsuariosAcessoProfile : Profile
    {
        public UsuariosAcessoProfile() 
        {
            CreateMap<UsuarioAcesso, UsuarioAcessoResponse>();
            CreateMap<UsuarioAcesso, UsuarioAcessoSessaoResponse>();
        }
    }
}