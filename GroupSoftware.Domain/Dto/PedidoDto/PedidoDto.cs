using System;
using System.Collections.Generic;

namespace GroupSoftware.Domain.Dto.PedidoDto
{
    public class PedidoDto
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid IdCliente { get; set; }
        public string StatusEntrega { get; set; }
        public List<Repository.Entities.ProdutoPedido> Produto { get; set; }
        public PedidoDto()
        {
            Produto = new List<Repository.Entities.ProdutoPedido>();
        }

        public static implicit operator PedidoDto(Repository.Entities.Pedido pedido)
        {
            return new PedidoDto
            {
                Id = pedido.Id == Guid.Empty ? Guid.NewGuid() : pedido.Id,
                DataCadastro = pedido.DataCadastro,
                IdCliente = pedido.IdCliente,
                StatusEntrega = pedido.StatusEntrega
            };
        }
    }
}
