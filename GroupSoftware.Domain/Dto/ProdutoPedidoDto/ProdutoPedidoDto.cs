using System;

namespace GroupSoftware.Domain.Dto.ProdutoPedido
{
    public class ProdutoPedidoDto
    {
        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public Guid IdPedido { get; set; }
        public int Quantidade { get; set; }

        public static implicit operator ProdutoPedidoDto(Repository.Entities.ProdutoPedido produtoPedido)
        {
            return new ProdutoPedidoDto
            {
                Id = produtoPedido.Id == Guid.Empty ? Guid.NewGuid() : produtoPedido.Id,
                IdProduto = produtoPedido.IdProduto,
                IdPedido = produtoPedido.IdPedido,
                Quantidade = produtoPedido.Quantidade
            };
        }
    }
}
