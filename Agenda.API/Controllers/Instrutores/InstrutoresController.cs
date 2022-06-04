using System.Collections.Generic;
using Agenda.Aplicacao.Instrutores.Servicos.Interfaces;
using Agenda.DataTransfer.Instrutores.Requests;
using Agenda.Dominio.Instrutores.Entidades;
using Agenda.DataTransfer.Instrutores.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers.Instrutores
{
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
        //[Authorize]
        public ActionResult<List<Instrutor>> ListarInstrutor([FromQuery] InstrutorListarRequest request)
        {
            var response = instrutorAppServico.Listar(request);
        
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<InstrutorResponse> Recuperar(int id)
        {
            var response = instrutorAppServico.Recuperar(id);

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<InstrutorResponse> Inserir(InstrutorInserirRequest request)
        {
            var response = instrutorAppServico.Inserir(request);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<InstrutorResponse> Atualizar(int id, InstrutorInserirRequest request)
        {
            var response = instrutorAppServico.Atualizar(id, request);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<InstrutorResponse> Deletar(int id)
        {
            var response = instrutorAppServico.Deletar(id);

            return Ok(response);
        }
    }
}