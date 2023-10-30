using Loja.Dtos.ClientMapper;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetAsync()
        {
            var result = await _clientService.GetAllClient();
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<ClientOrderDTO>>> GetOrder()
        {
            var result = await _clientService.GetClientOrders();
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _clientService.GetClientById(id);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("Cnpj")]
        public async Task<IActionResult> GetByCNPJAsync(string cnpj)
        {
            var result = await _clientService.GetByCNPJ(cnpj);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ClientDTO>> PostAsync(PostClientDTO client)
        {
            var result = await _clientService.CreateClient(client);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(long id, ClientDTO client)
        {
            var result = await _clientService.PutClient(id, client);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _clientService.DeleteClient(id);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        //[HttpPost("order")]
        //public async Task<IActionResult> ClientOrderAsync(string name, int quant)
        //{
        //    var result = await _clientService.CreateOrder(name, quant);
        //    if (result is null)
        //    {
        //        return BadRequest("pediu demais ou o produto nao existe meu parça");
        //    }
        //    return Ok(result);
        //}
    }
}
