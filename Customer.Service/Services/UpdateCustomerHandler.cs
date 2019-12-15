using Customer.Data.IRepositories;
using Customer.Domain.Commands;
using Customer.Domain.Dtos;
using Customer.Service.Dxos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.Services
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerDxos _customerDxos;
        private readonly IMediator _mediator;

        public UpdateCustomerHandler(ICustomerRepository customerRepository, IMediator mediator, ICustomerDxos customerDxos)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _customerDxos = customerDxos ?? throw new ArgumentNullException(nameof(customerDxos));
        }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            // 3) Maak handler
            var customer = await _customerRepository.GetAsync(e =>
                e.Id == request.Id);

            var oldName = customer.Name;

            if(customer == null)
            {
                throw new ArgumentException($"The user with name {request.Name} does not exist!", nameof(request.Name));
            }

            customer.Name = request.Name;

            _customerRepository.Update(customer);

            if (await _customerRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException();
            }

            await _mediator.Publish(new Domain.Events.CustomerUpdatedEvent(customer.Id, oldName), cancellationToken);

            var customerDto = _customerDxos.MapCustomerDto(customer);
            return customerDto;
        }
    }
}
