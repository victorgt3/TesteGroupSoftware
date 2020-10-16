using GroupSoftware.Domain.Dto.ProdutoDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GroupSoftware.Domain.Command.ProdutoPedidoCommand
{
    public class ProdutoPedidoAddCommand : IRequest<IActionResult>
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid IdCliente { get; set; }
        public string StatusEntrega { get; set; }
        public List<ProdutoDto> Produto { get; set; }
        public ProdutoPedidoAddCommand()
        {
            Produto = new List<ProdutoDto>();
        }
        public int Quantidade { get; set; }
    }
}
