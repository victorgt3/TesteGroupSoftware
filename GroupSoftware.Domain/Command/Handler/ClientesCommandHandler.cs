using GroupSoftware.Domain.Command.ClientesCommand;
using GroupSoftware.Domain.Dto.ClienteDto;
using GroupSoftware.Repository.Entities;
using GroupSoftware.Repository.Repositories.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace GroupSoftware.Domain.Command.Handler
{
    public class ClientesCommandHandler : ControllerBase,
        IRequestHandler<ClienteAddCommand, ActionResult<ClienteDto>>,
        IRequestHandler<ClientePutCommand, ActionResult<ClienteDto>>

    {
        private readonly IGenericRepository<Cliente> _repositoryCliente;
        public ClientesCommandHandler(IGenericRepository<Cliente> repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }
        public async Task<ActionResult<ClienteDto>> Handle(ClienteAddCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repositoryCliente.AddAsync(request);

            ClienteDto clienteDto = cliente;

            return Created("", clienteDto);
        }

        public async Task<ActionResult<ClienteDto>> Handle(ClientePutCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repositoryCliente.UpdateAsync(request);

            ClienteDto clienteDto = cliente;

            return Created("", clienteDto);
        }
    }
}
