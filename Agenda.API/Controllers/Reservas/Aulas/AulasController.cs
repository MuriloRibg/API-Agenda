// Importação internar 
using Agenda.Aplicacao.Aulas.Servicos.Interfaces;
using Agenda.Dominio.Aulas.Entidades;
using Agenda.DataTransfer.Aulas.Requests;

//Libs internas
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Dominio.Excecoes;
using Libraries.Dominio.Consultas;

//Lins externas
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers.Aulas
{
    [Route("aulas")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        private readonly IAulasAppServico aulaAppServico;

        public AulasController(IAulasAppServico aulaAppServico)
        {
            this.aulaAppServico = aulaAppServico;
        }

        ///<summary>
        /// Listar Aulas
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<PaginacaoConsulta<Aula>> ListarAulas([FromQuery] AulaListarRequest request)
        {
            return Ok(aulaAppServico.Listar(request));
        }
    }
}
