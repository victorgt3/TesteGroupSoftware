using GroupSoftware.Domain.Command.PedidosCommand;
using GroupSoftware.Domain.Command.ProdutoPedidoCommand;
using GroupSoftware.Domain.Command.ProdutosCommand;
using GroupSoftware.Repository.Entities;
using GroupSoftware.Repository.Repositories.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GroupSoftware.Domain.Command.Handler
{
    public class ProdutoPedidoCommandHandler : ControllerBase,
        IRequestHandler<ProdutoPedidoAddCommand, IActionResult>
    {
        private readonly IGenericRepository<Produto> _repositoryProduto;
        private readonly IGenericRepository<Pedido> _repositoryPedido;
        private readonly IGenericRepository<ProdutoPedido> _repositoryPedidoProduto;
        public ProdutoPedidoCommandHandler(IGenericRepository<Produto> repositoryProduto,
           IGenericRepository<Pedido> repositoryPedido,
           IGenericRepository<ProdutoPedido> repositoryPedidoProduto)
        {
            _repositoryProduto = repositoryProduto;
            _repositoryPedido = repositoryPedido;
            _repositoryPedidoProduto = repositoryPedidoProduto;
        }
        public async Task<IActionResult> Handle(ProdutoPedidoAddCommand request, CancellationToken cancellationToken)
        {
            var pedido = new PedidoAddCommand()
            {
                Id = request.Id,
                IdCliente = request.IdCliente,
                DataCadastro = request.DataCadastro,
                StatusEntrega = request.StatusEntrega
            };

            await _repositoryPedido.AddAsync(pedido);

            foreach (var item in request.Produto)
            {
                var produto = new ProdutoAddCommand()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Valor = item.Valor,
                    Disponivel = item.Disponivel
                };

                await _repositoryProduto.AddAsync(produto);

                var pedidoProduto = new ProdutoPedidoPostCommand()
                {
                    Id = Guid.NewGuid(),
                    IdPedido = request.Id,
                    IdProduto = item.Id,
                    Quantidade = request.Quantidade
                };

                await _repositoryPedidoProduto.AddAsync(pedidoProduto);
            }
           

            return Created("", request);
        }
    }
}
