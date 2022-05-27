using Agenda.Aplicacao.Disciplinas.Servicos.Interfaces;
using Agenda.DataTransfer.Disciplinas.Requests;
using Agenda.DataTransfer.Disciplinas.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers.Disciplinas
{
    [Route("api/disciplinas")]
    [ApiController]
    public class DisciplinasController : Controller
    {
        private readonly IDisciplinasAppServico disciplinasAppServico;

        public DisciplinasController(IDisciplinasAppServico disciplinasAppServico)
        {
            this.disciplinasAppServico = disciplinasAppServico;
        }

        ///<summary>
        /// Listar Disciplinas
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        public ActionResult<DisciplinaResponse> Listar([FromQuery] DisciplinaListarRequest request)
        {
            return Ok(disciplinasAppServico.Listar(request));
        }
        
        /// <summary>
        /// Recuperar uma Disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        public ActionResult<DisciplinaResponse> Recuperar(int id)
        {
            var response = disciplinasAppServico.Recuperar(id);
            return Ok(response);
        }

        /// <summary>
        /// Inserir uma novo Disciplina
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>  
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<DisciplinaResponse> Inserir([FromBody] DisciplinaInserirRequest request)
        {
            if (request == null)
                return BadRequest(request);

            var response = disciplinasAppServico.Inserir(request);

            return Ok(response);
        }

        /// <summary>
        /// Editar uma Disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<DisciplinaResponse> Editar(int id, [FromBody] DisciplinaEditarRequest request)
        {
            if (request == null)
                return BadRequest();

            var response = disciplinasAppServico.Editar(id, request);

            return Ok(response);
        }

        /// <summary>
        /// Apagar uma Disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [Produces("application/json")]
        public ActionResult Excluir(int id)
        {
            disciplinasAppServico.Excluir(id);
            return Ok();
        }
    }
}