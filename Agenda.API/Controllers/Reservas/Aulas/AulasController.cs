using System.Collections.Generic;
using Agenda.Aplicacao.Aulas.Servicos.Interfaces;
using Agenda.Dominio.Aulas.Entidades;
using Agenda.DataTransfer.Aulas.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Dominio.Excecoes;
using Libraries.Dominio.Consultas;

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
        //[Authorize]
        public ActionResult<PaginacaoConsulta<Aula>> ListarAulas([FromQuery] AulaListarRequest request)
        {
            var response = aulaAppServico.Listar(request);
        
            return Ok(response);
        }
    }
}