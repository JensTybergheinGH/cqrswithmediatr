using Customer.Domain.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Customer.Domain.Commands
{
    // 2) Maken van het command (properties die zullen verstuurd worden) 
    public class UpdateCustomerCommand : CommandBase<CustomerDto>
    {
        public UpdateCustomerCommand()
        {

        }

        [JsonConstructor]
        public UpdateCustomerCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        [JsonProperty("id")]
        [Required]
        public Guid Id { get; }

        [JsonProperty("name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; }
    }
}
