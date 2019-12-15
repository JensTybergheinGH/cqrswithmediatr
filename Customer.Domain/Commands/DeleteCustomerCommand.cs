using Customer.Domain.Dtos;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Customer.Domain.Commands
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public DeleteCustomerCommand()
        {

        }

        [JsonConstructor]
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }


        [JsonProperty("id")]
        [Required]
        public Guid Id { get; }
    }
}
