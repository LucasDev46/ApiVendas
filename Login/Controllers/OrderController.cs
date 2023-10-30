using Loja.Dtos.OrderMapper;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService clientService)
        {
            _orderService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAsync()
        {
            var result = await _orderService.GetAllOrder();
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _orderService.GetOrderById(id);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
   
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(string client, int product, int quant)
        {
            var result = await _orderService.CreateOrder(client, product, quant);
            if (result is null)
            {
                return BadRequest("hmm, sei nao em");
            }
            return Ok(result);
        }
    }
}
