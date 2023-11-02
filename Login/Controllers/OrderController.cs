using Loja.Dtos.OrderMapper;
using Loja.Errors;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllAsync()
        {
            var result = await _orderService.GetAllOrder();
            if (result is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = "Error" });
            }
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetOrderByIdAsync(long id)
        {
            var result = await _orderService.GetOrderById(id);
            if (result is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = "Error" });
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Manager, Client")]
        public async Task<IActionResult> CreateOrderAsync(OrderDTO order)
        {
            var result = await _orderService.CreateOrder(order);
            if (result is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = "Error" });
            }
            return Ok(result);
        }
    }
}
