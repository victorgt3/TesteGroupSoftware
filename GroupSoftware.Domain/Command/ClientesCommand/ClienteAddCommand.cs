using GroupSoftware.Domain.Dto.ClienteDto;
using GroupSoftware.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;


namespace GroupSoftware.Domain.Command.ClientesCommand
{
    public class ClienteAddCommand : IRequest<ActionResult<ClienteDto>>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Status { get; set; }

        public static implicit operator Cliente(ClienteAddCommand cliente)
        {
            return new Cliente 
            {
              Id = cliente.Id,
              Nome = cliente.Nome,
              DataCadastro = cliente.DataCadastro,
              Status = cliente.Status
            };
        }
    }
}
