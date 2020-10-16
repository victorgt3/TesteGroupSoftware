using GroupSoftware.Repository.Entities;
using System;

namespace GroupSoftware.Domain.Dto.ProdutoDto
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public bool Disponivel { get; set; }

        public static implicit operator ProdutoDto(Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.Id == Guid.Empty ? Guid.NewGuid() : produto.Id,
                Nome = produto.Nome,
                Valor = produto.Valor,
                Disponivel = produto.Disponivel
            };
        }
    }
}
