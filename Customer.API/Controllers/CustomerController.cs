using System;
using System.Threading.Tasks;
using Customer.Domain.Commands;
using Customer.Domain.Dtos;
using Customer.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{

    public class CustomerController : ApiControllerBase

    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Get customer by id
        /// </summary>
        /// <param name="id">Id of customer</param>
        /// <returns>Customer information</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CustomerDto>> GetCustomerAsync(Guid id)
        {
            return Single(await QueryAsync(new GetCustomerQuery(id)));
        }

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="command">Info of customer</param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateCustomerAsync([FromBody] CreateCustomerCommand command)
        {
            return Ok(await CommandAsync(command));
        }

        /// <summary>
        /// Update customer>
        /// <param name="command">Info of customer</param>
        /// <returns></returns>
        [HttpPost("update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateCustomerAsync([FromBody] UpdateCustomerCommand command)
        {
            // 1) Toevoegen van de actie in de controller
            return Ok(await CommandAsync(command));
        }

        /// <summary>
        /// Update customer>
        /// <param name="command">Info of customer</param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> DeleteCustomerAsync([FromBody] DeleteCustomerCommand command)
        {
            return Ok(await CommandAsync(command));
        }
    }
}