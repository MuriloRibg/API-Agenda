using System.Collections.Generic;
using Agenda.Aplicacao.Instrutores.Servicos.Interfaces;
using Agenda.DataTransfer.Instrutores.Requests;
using Agenda.DataTransfer.Instrutores.Responses;
using Agenda.Dominio.Instrutores.Entidades;
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
        
        [HttpGet]
        //[Authorize]
        public ActionResult<List<Instrutor>> ListarInstrutor()
        {
            var response = instrutorAppServico.Listar();
        
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
        public ActionResult<InstrutorResponse> Inserir(InstrutorRequest request)
        {
            var response = instrutorAppServico.Inserir(request);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<InstrutorResponse> Atualizar(int id, InstrutorRequest request)
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