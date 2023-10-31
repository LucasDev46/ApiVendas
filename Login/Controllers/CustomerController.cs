using Loja.Dtos.ClientMapper;
using Loja.Errors;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "Manager")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _clientService;

        public CustomerController(ICustomerService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomerAsync()
        {
            var result = await _clientService.GetAllCustomer();
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<CustomerOrderDTO>>> GetOrder()
        {
            var result = await _clientService.GetCustomerOrders();
            if (result is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = "Error" });
            }
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _clientService.GetCustomerById(id);
            if (result is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = "Client not Found" });
            }
            return Ok(result);
        }
        [HttpGet("Cnpj")]
        public async Task<IActionResult> GetByCNPJAsync(string cnpj)
        {
            var result = await _clientService.GetCustomerByCNPJ(cnpj);
            if (result is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = "Client not Found" });
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateClient(long id, CustomerDTO client)
        {
            var result = await _clientService.UpdateCustomer(id, client);
            if (result is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = "Error" });
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _clientService.DeleteCustomer(id);
            if (result is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = "Client not Found" });
            }
            return Ok(result);
        }
    }
}
