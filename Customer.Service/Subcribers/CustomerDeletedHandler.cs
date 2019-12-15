using Customer.Data.IRepositories;
using Customer.Domain.Dtos;
using Customer.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.Subcribers
{
    public class CustomerDeletedHandler : INotificationHandler<CustomerDeletedEvent>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger _logger;

        public CustomerDeletedHandler(ICustomerRepository customerRepository, ILogger<CustomerCreatedHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger;
        }

        public async Task Handle(CustomerDeletedEvent notification, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(e => e.Id == notification.Id);
            _logger.LogInformation($"The customer with the name {notification.Name} was deleted");
        }
    }
}
