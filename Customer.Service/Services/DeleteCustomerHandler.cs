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
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerDxos _customerDxos;
        private readonly IMediator _mediator;

        public DeleteCustomerHandler(ICustomerRepository customerRepository, IMediator mediator, ICustomerDxos customerDxos)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _customerDxos = customerDxos ?? throw new ArgumentNullException(nameof(customerDxos));
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(e =>
                e.Id == request.Id);
            
            if (customer == null)
            {
                throw new ArgumentException($"This user does not exist!");
            }

            var id = customer.Id;
            var name = customer.Name;

            _customerRepository.Remove(customer);

            if (await _customerRepository.SaveChangesAsync() == 0)
            {
                return false;
                throw new ApplicationException();
            }

            await _mediator.Publish(new Domain.Events.CustomerDeletedEvent(id, name), cancellationToken);

            return true;
        }
    }
}
