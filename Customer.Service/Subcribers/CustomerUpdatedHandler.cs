using Customer.Data.IRepositories;
using Customer.Domain.Commands;
using Customer.Domain.Dtos;
using Customer.Domain.Events;
using Customer.Service.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.Subcribers
{
    public class CustomerUpdatedHandler : INotificationHandler<CustomerUpdatedEvent>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger _logger;

        public CustomerUpdatedHandler(ICustomerRepository customerRepository, ILogger<CustomerCreatedHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger;
        }

        public async Task Handle(CustomerUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(e => e.Id == notification.CustomerId);

            if (customer == null)
            {
                //TODO: Handle next business logic if customer is not found
                _logger.LogWarning("Customer is not found by customer id from publisher");
            }
            else
            {
                _logger.LogInformation($"Customer has updated his name from {notification.OldName} to {customer.Name}");
            }
        }
    }
}
