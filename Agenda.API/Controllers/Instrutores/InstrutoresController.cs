using System.Collections.Generic;
using Agenda.Aplicacao.Instrutores.Servicos.Interfaces;
using Agenda.DataTransfer.Instrutores.Requests;
using Agenda.Dominio.Instrutores.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers.Instrutores
{
    [Route("api/instrutores")]
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
            return Ok(instrutorAppServico.Listar(request));
        }
    }
}