using Agenda.Aplicacao.Locais.Servicos.Interfaces;
using Agenda.DataTransfer.Locais.Requests;
using Agenda.DataTransfer.Locais.Responses;

using Libraries.Dominio.Consultas;
using Libraries.Util.Extensoes;

using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers.Locais
{
    /// <summary>
    /// Controller de Locais
    /// </summary>
    [Route("api/locais")]
    [ApiController]
    public class LocaisController : Controller
    {
        private readonly ILocaisAppServico locaisAppServico;

        /// <summary>
        /// Contrutor da classe LocaisController
        /// </summary>
        /// <param name="locaisAppServico"></param>
        public LocaisController(ILocaisAppServico locaisAppServico)
        {
            this.locaisAppServico = locaisAppServico;
        }
        
        ///<summary>
        /// Listar os Locais
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        public ActionResult<PaginacaoConsulta<LocalResponse>> Listar([FromQuery] LocalListarRequest request)
        {
            return Ok(locaisAppServico.Listar(request));
        }
        
        /// <summary>
        /// Recuperar um Local
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        public ActionResult<LocalResponse> Recuperar(int id)
        {
            return Ok(locaisAppServico.Recuperar(id));
        }
        
        /// <summary>
        /// Inserir um novo Local
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>  
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<LocalResponse> Inserir([FromBody] LocalInserirRequest request)
        {
            return request is null ? BadRequest() : Ok(locaisAppServico.Inserir(request));
        }
        
        /// <summary>
        /// Editar um Local
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<LocalResponse> Editar(int id, [FromBody] LocalEditarRequest request)
        {
            return request is null ?  BadRequest() : Ok(locaisAppServico.Editar(id, request));
        }

        /// <summary>
        /// Apagar um Local
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [Produces("application/json")]
        public ActionResult Excluir(int id)
        {
            locaisAppServico.Excluir(id);
            return Ok();
        }
    }
}
