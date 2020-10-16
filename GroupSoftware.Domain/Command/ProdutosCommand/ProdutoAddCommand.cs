using GroupSoftware.Domain.Dto.ProdutoDto;
using GroupSoftware.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GroupSoftware.Domain.Command.ProdutosCommand
{
    public class ProdutoAddCommand : IRequest<ActionResult<ProdutoDto>>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public bool Disponivel { get; set; }

        public static implicit operator Produto(ProdutoAddCommand produto)
        {
            return new Produto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Valor = produto.Valor,
                Disponivel = produto.Disponivel
            };
        }
    }
}
