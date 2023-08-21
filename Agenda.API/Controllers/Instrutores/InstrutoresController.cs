//Importação interna
using Agenda.Aplicacao.Instrutores.Servicos.Interfaces;
using Agenda.DataTransfer.Instrutores.Requests;
using Agenda.Dominio.Instrutores.Entidades;
using Agenda.DataTransfer.Instrutores.Responses;

//Libs microsoft
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace Agenda.API.Controllers.Instrutores
{
    /// <summary>
    /// Controller da Disciplina
    /// </summary>
    [Route("instrutores")]
    [ApiController]
    public class InstrutoresController : ControllerBase
    {
        private readonly IInstrutorAppServico instrutorAppServico;

        public InstrutoresController(IInstrutorAppServico instrutorAppServico)
        {
            this.instrutorAppServico = instrutorAppServico;
        }

        ///<summary>
        /// Listar Instrutores
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<List<Instrutor>> ListarInstrutor([FromQuery] InstrutorListarRequest request)
        {
            return Ok(instrutorAppServico.Listar(request));
        }

        ///<summary>
        /// Recupera o id do instrutor a partir do ID 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<InstrutorResponse> Recuperar(int id)
        {
            return Ok(instrutorAppServico.Recuperar(id));
        }

        ///<summary>
        /// Recuperar o instrutor a parti da aula
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/aula/{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<InstrutorResponse> RecuperarPorAula(int id)
        {
            return Ok(instrutorAppServico.InstrutorPorAula(id));
        }

        ///<summary>
        /// Inserir um novo instrutor
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<InstrutorResponse> Inserir(InstrutorInserirRequest request)
        {
            return Ok(instrutorAppServico.Inserir(request));
        }

        ///<summary>
        /// Atualizar um instrutor  
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<InstrutorResponse> Atualizar(int id, InstrutorInserirRequest request)
        {
            return Ok(instrutorAppServico.Atualizar(id, request));
        }

        ///<summary>
        /// Deletar um instrututor
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<InstrutorResponse> Deletar(int id)
        {
            return Ok(instrutorAppServico.Deletar(id));
        }
    }
}
