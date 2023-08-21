//Importação interna
using Agenda.Aplicacao.Disciplinas.Servicos.Interfaces;
using Agenda.DataTransfer.Disciplinas.Requests;
using Agenda.DataTransfer.Disciplinas.Responses;

//Libs interna
using Libraries.Dominio.Consultas;
using Libraries.Util.Extensoes;

//Libs microsoft
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers.Disciplinas
{
    /// <summary>
    /// Controller da Disciplina
    /// </summary>
    [Route("api/disciplinas")]
    [ApiController]
    public class DisciplinasController : Controller
    {
        private readonly IDisciplinasAppServico disciplinasAppServico;

        /// <summary>
        /// Contrutor do controller
        /// </summary>
        /// <param name="disciplinasAppServico"></param>
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
        public PaginacaoConsulta<DisciplinaResponse> Listar([FromQuery] DisciplinaListarRequest request)
        {
            return disciplinasAppServico.Listar(request);
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
            return Ok(disciplinasAppServico.Recuperar(id));
        }

        /// <summary>
        /// Inserir uma nova Disciplina
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>  
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<DisciplinaResponse> Inserir([FromBody] DisciplinaInserirRequest request)
        {
            return request is null ?  BadRequest() : Ok(disciplinasAppServico.Inserir(request));
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
            return request is null ?  BadRequest() : Ok(disciplinasAppServico.Editar(id, request));
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
