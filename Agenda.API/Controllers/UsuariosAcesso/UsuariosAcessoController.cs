using Agenda.Aplicacao.UsuariosAcesso.Servicos.Interfaces;
using Agenda.DataTransfer.UsuariosAcesso.Requests;
using Agenda.DataTransfer.UsuariosAcesso.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers.UsuariosAcesso
{
    [ApiController]
    public class UsuariosAcessoController : ControllerBase
    {
        private readonly IUsuariosAcessoAppServico usuariosAcessoAppServico;

        public UsuariosAcessoController(IUsuariosAcessoAppServico usuariosAcessoAppServico) 
        {
            this.usuariosAcessoAppServico = usuariosAcessoAppServico;
        }

        [HttpPost]
        [Route("api/usuariosAcesso")]
        public ActionResult<UsuarioAcessoResponse> Cadastrar([FromBody] UsuarioAcessoRequest request)
        {
            var response = usuariosAcessoAppServico.Inserir(request);

            return Ok(response);
        }
    }
}