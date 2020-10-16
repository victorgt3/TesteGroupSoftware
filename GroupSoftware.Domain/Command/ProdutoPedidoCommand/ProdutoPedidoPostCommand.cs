using GroupSoftware.Domain.Dto.ProdutoPedido;
using GroupSoftware.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GroupSoftware.Domain.Command.ProdutoPedidoCommand
{
    public class ProdutoPedidoPostCommand : IRequest<ActionResult<ProdutoPedidoDto>>
    {
        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public Guid IdPedido { get; set; }
        public int Quantidade { get; set; }

        public static implicit operator ProdutoPedido(ProdutoPedidoPostCommand pedidoProduto)
        {
            return new ProdutoPedido
            {
                Id = pedidoProduto.Id == Guid.Empty ? Guid.NewGuid() : pedidoProduto.Id,
                IdPedido = pedidoProduto.IdPedido,
                IdProduto = pedidoProduto.IdProduto,
                Quantidade = pedidoProduto.Quantidade
            };
        }
    }
}
