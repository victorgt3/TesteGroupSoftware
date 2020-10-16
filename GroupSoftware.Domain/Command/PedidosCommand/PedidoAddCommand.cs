using GroupSoftware.Domain.Dto.PedidoDto;
using GroupSoftware.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GroupSoftware.Domain.Command.PedidosCommand
{
    public  class PedidoAddCommand : IRequest<ActionResult<PedidoDto>>
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid IdCliente { get; set; }
        public string StatusEntrega { get; set; }

        public static implicit operator Pedido(PedidoAddCommand pedido)
        {
            return new Pedido
            {
                Id = pedido.Id,
                DataCadastro = pedido.DataCadastro,
                IdCliente = pedido.IdCliente,
                StatusEntrega = pedido.StatusEntrega
            };
        }
    }
}
