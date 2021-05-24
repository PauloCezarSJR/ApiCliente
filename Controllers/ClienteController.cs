using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiCliente.Data;
using ApiCliente.Dominio;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiCliente.Repository;

namespace ApiCliente.Controllers
{
    [Route("v1/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Get([FromServices] DataContext context)
        {
            IClienteRepository clienteRepo = new ClienteRepository(context);
            return await clienteRepo.ListarTodos();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cliente>> Post([FromServices] DataContext context, [FromBody] Cliente model)
        {
            try
            {
                IClienteRepository clienteRepo = new ClienteRepository(context);
                return await clienteRepo.Adicionar(model);
            }
            catch (System.Exception e)
            {
                return BadRequest(new JsonResult(new { mensagem = e.Message, campo = e.Source }));
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Cliente>> Put([FromServices] DataContext context, [FromBody] Cliente model)
        {
            try
            {
                IClienteRepository clienteRepo = new ClienteRepository(context);
                await clienteRepo.Atualizar(model);
                return model;
            }
            catch(System.Exception e)
            {
                return BadRequest(new JsonResult(new { mensagem = e.Message, campo = e.Source }));
            }
        }

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<object>> Delete([FromServices] DataContext context, [FromBody] Cliente model)
        {
            try
            {
                IClienteRepository clienteRepo = new ClienteRepository(context);
                return await clienteRepo.Excluir(model.id);
            }
            catch (System.Exception e)
            {
                return BadRequest(new JsonResult(new { mensagem = e.Message, campo = e.Source }));
            }
        }

    }
}
