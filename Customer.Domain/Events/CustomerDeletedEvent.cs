using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain.Events
{
    public class CustomerDeletedEvent : INotification
    {
        public Guid Id { get; set; }
        public string Name { get; }

        public CustomerDeletedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
