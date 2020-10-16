using GroupSoftware.Domain.Command.ClientesCommand;
using GroupSoftware.Domain.Command.ProdutoPedidoCommand;
using GroupSoftware.Domain.DependencyInjection.Configuration.ErroHandler;
using GroupSoftware.Domain.Dto.ClienteDto;
using GroupSoftware.Domain.Dto.PedidoDto;
using GroupSoftware.Repository.Entities;
using GroupSoftware.Repository.Repositories.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GroupSoftware.Api.Controllers
{
    [ApiController]
    [Route("ecommerce/v1/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IGenericRepository<Cliente> _repositoryCliente;
        private readonly IGenericRepository<Pedido> _repositoryPedido; 
        private readonly IGenericRepository<ProdutoPedido> _repositoryPedidoProduto;
        private readonly IMediator _mediator;
        public ClientesController(IGenericRepository<Cliente> repositoryCliente, 
            IMediator mediator, IGenericRepository<Pedido> repositoryPedido,
            IGenericRepository<ProdutoPedido> repositoryPedidoProduto )
        {
            _repositoryCliente = repositoryCliente;
            _mediator = mediator;
            _repositoryPedido = repositoryPedido;
            _repositoryPedidoProduto = repositoryPedidoProduto;
        }

        [HttpGet]
        public virtual async Task<ActionResult<ClienteDto>> Get()
        {
           
            return Ok(await _repositoryCliente.GetAllAsync());
        }

        [HttpPost]
        public virtual async Task<ActionResult<ClienteDto>> Post(ClienteAddCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("{idCliente}")]
        public async Task<ActionResult<ClienteDto>> GetById(Guid idCliente)
        {
            var cliente = await _repositoryCliente.GetByIdAsync(idCliente);
            if (cliente == null)
            {
                return NotFound(new ErroHandlerResponse(404, "Cliente not found"));
            }
            ClienteDto clienteDto = cliente;
          
            return Ok(clienteDto);
        }


        [HttpPut]
        public virtual async Task<ActionResult<ClienteDto>> Put(ClientePutCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("{idCliente}/pedidos")]
        public async Task<ActionResult<PedidoDto>> GetPedidosById(Guid idCliente)
        {
            var pedido = await _repositoryPedido.GetAsync(e => e.IdCliente == idCliente);
            if (pedido == null)
            {
                return NotFound(new ErroHandlerResponse(404, "Cliente not found"));
            }
            PedidoDto pedidoDto = pedido;

            var produtoPedido = await _repositoryPedidoProduto.GetWhwereAllAsync(e => e.IdPedido == pedido.Id);

            pedidoDto.Produto = produtoPedido;

            return Ok(pedidoDto);
        }


        [HttpPost("{idCliente}/pedidos")]
        public virtual async Task<IActionResult> PostProdutoPedido(ProdutoPedidoAddCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
