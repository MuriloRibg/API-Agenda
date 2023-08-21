//Importações internas
using Agenda.Aplicacao.UsuariosAcesso.Servicos.Interfaces;
using Agenda.DataTransfer.UsuariosAcesso.Requests;
using Agenda.DataTransfer.UsuariosAcesso.Responses;

//Libs externas
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
            var response = usuariosAcessoAppServico.Cadastrar(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("api/autenticar")]
        public ActionResult<UsuarioAcessoSessaoResponse> Autenticar([FromBody] UsuarioAcessoAutenticacaoRequest request)
        {
            return Ok(usuariosAcessoAppServico.Autenticar(request));
        }
    }
}
