using GroupSoftware.Domain.DependencyInjection.Configuration.ErroHandler;
using GroupSoftware.Domain.Dto.PedidoDto;
using GroupSoftware.Repository.Entities;
using GroupSoftware.Repository.Repositories.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GroupSoftware.Api.Controllers
{
    [ApiController]
    [Route("ecommerce/v1/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IGenericRepository<Pedido> _repositoryPedido;
        public PedidosController(IGenericRepository<Pedido> repositoryPedido)
        {
            _repositoryPedido = repositoryPedido;
        }

        [HttpGet]
        public async Task<ActionResult<PedidoDto>> GetById(string statusEntrega)
        {
            var cliente = await _repositoryPedido.GetAsync(e => e.StatusEntrega == statusEntrega);
            if (cliente == null)
            {
                return NotFound(new ErroHandlerResponse(404, "Cliente not found"));
            }
            PedidoDto clienteDto = cliente;

            return Ok(clienteDto);
        }
    }
}
