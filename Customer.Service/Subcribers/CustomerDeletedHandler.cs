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
        private readonly ILogger _logger;

        public CustomerDeletedHandler(ILogger<CustomerCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CustomerDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"The customer with the name {notification.Name} was deleted");
            return Task.CompletedTask;
        }
    }
}
