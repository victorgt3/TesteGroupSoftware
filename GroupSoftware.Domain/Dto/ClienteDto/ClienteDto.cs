using GroupSoftware.Repository.Entities;
using System;

namespace GroupSoftware.Domain.Dto.ClienteDto
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Status { get; set; }

        public static implicit operator ClienteDto(Cliente cliente)
        {
            return new ClienteDto
            {
                Id = cliente.Id == Guid.Empty ? Guid.NewGuid() : cliente.Id,
                Nome = cliente.Nome,
                DataCadastro = cliente.DataCadastro,
                Status = cliente.Status                
            };
        }
    }
}
