using System.Collections.Generic;
using Agenda.Aplicacao.Instrutores.Servicos.Interfaces;
using Agenda.Dominio.Instrutores.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers.Instrutores
{
    [ApiController]
    public class InstrutoresController : ControllerBase
    {
        private readonly IInstrutorAppServico instrutorAppServico;

        public InstrutoresController(IInstrutorAppServico instrutorAppServico)
        {
            this.instrutorAppServico = instrutorAppServico;
        }
        
        [HttpGet]
        [Route("api/instrutores")]
        public ActionResult<List<Instrutor>> ListarInstrutor()
        {
            var response = instrutorAppServico.Listar();
            return Ok(response);
        }
    }
}