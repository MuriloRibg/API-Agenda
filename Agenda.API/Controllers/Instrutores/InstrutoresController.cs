using System.Collections.Generic;
using Agenda.Aplicacao.Instrutores.Servicos.Interfaces;
using Agenda.DataTransfer.Instrutores.Requests;
<<<<<<< HEAD
using Agenda.DataTransfer.Instrutores.Responses;
=======
>>>>>>> 4028d23cfa0ea3d739b7d969d1a135902f36288c
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

        ///<summary>
        /// Listar Instrutores
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        public ActionResult<List<Instrutor>> ListarInstrutor([FromQuery] InstrutorListarRequest request)
        {
<<<<<<< HEAD
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
=======
            return Ok(instrutorAppServico.Listar(request));
>>>>>>> 4028d23cfa0ea3d739b7d969d1a135902f36288c
        }
    }
}