using System.Collections.Generic;
using Agenda.Aplicacao.Instrutores.Servicos.Interfaces;
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
        
        [HttpGet]
        [Authorize]
        public ActionResult<List<Instrutor>> ListarInstrutor()
        {
            var response = instrutorAppServico.Listar();
            return Ok(response);
        }
    }
}