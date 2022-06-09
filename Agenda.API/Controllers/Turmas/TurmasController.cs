using Agenda.Aplicacao.Turmas.Servicos.Interfaces;
using Agenda.DataTransfer.Disciplinas.Requests;
using Agenda.DataTransfer.Disciplinas.Responses;
using Agenda.DataTransfer.Turmas.Requests;
using Agenda.DataTransfer.Turmas.Responses;
using Libraries.Dominio.Consultas;
using Libraries.Util.Extensoes;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers.Turmas
{
    /// <summary>
    /// Controller da Turma
    /// </summary>
    [Route("api/turmas")]
    [ApiController]
    public class TurmasController : Controller
    {
        private readonly ITurmasAppServico turmasAppServico;

        /// <summary>
        /// Contrutor do controller
        /// </summary>
        /// <param name="turmasAppServico"></param>
        public TurmasController(ITurmasAppServico turmasAppServico)
        {
            this.turmasAppServico = turmasAppServico;
        }
        ///<summary>
        /// Listar Turmas
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        public PaginacaoConsulta<TurmaResponse> Listar([FromQuery] TurmaListarRequest request)
        {
            return turmasAppServico.Listar(request);
        }
        
        /// <summary>
        /// Recuperar uma Turma
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        public ActionResult<TurmaResponse> Recuperar(int id)
        {
            return Ok(turmasAppServico.Recuperar(id));
        }

        /// <summary>
        /// Inserir uma nova Turma
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>  
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<TurmaResponse> Inserir([FromBody] TurmaInserirRequest request)
        {
            if (request.IsNull())
                return BadRequest();
            return Ok(turmasAppServico.Inserir(request));
        }

        /// <summary>
        /// Editar uma turma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<TurmaResponse> Editar(int id, [FromBody] TurmaEditarRequest request)
        {
            if (request.IsNull())
                return BadRequest();
            return Ok(turmasAppServico.Editar(id, request));
        }

        /// <summary>
        /// Apagar uma turma
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [Produces("application/json")]
        public ActionResult Excluir(int id)
        {
            turmasAppServico.Excluir(id);
            return Ok();
        }
    }
}