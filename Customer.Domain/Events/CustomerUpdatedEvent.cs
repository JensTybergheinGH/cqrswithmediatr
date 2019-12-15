using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain.Events
{
    public class CustomerUpdatedEvent : INotification
    {
        public Guid CustomerId { get; }
        public string OldName { get; set; }

        public CustomerUpdatedEvent(Guid customerId, string oldName)
        {
            CustomerId = customerId;
            OldName = oldName;
        }
    }
}
