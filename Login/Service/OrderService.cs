using AutoMapper;
using Loja.Dtos.OrderMapper;
using Loja.Models;
using Loja.Repository.Interface;
using Loja.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Service;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    } 

    public async Task<IEnumerable<OrderDTO>> GetAllOrder()
    {
        var orders = await _unitOfWork._orderRepository.SelectAll().Include(p => p.Client).Include(p => p.Products).ToListAsync();
        if (orders is null)
        {
            return null;
        }      
        var ordersDto = _mapper.Map<List<OrderDTO>>(orders);
        return ordersDto;
    }

    public async Task<OrderDTO> GetOrderById(long id)
    {
        var order = await _unitOfWork._orderRepository.SelectAll().Include(p => p.Client).Include(o => o.Products).FirstOrDefaultAsync(p => p.OrderId == id);
        if (order is null)
        {
            return null;
        }

        var orderDto = _mapper.Map<OrderDTO>(order);
        return orderDto;
    }

    public async Task<OrderDTO> CreateOrder(string cnpj, long productId, int quant)
    {
        var client = await _unitOfWork._customerRepository.SelectByQuery(p => p.CNPJ == cnpj);
        var product = await _unitOfWork._productRepository.SelectByQuery(p => p.ProductId == productId);
        
        if (product is null || client is null)
        {
            return null;
        }
        var order = new Order
        {
            Client = client,
            Date = DateTime.UtcNow,
            Quantity = quant,
            TotalValue = product.Price * quant,
            ProductId = productId
        };
        order.Products.Add(product);
        client.Order.Add(order);
        product.stock -= quant;

        _unitOfWork._productRepository.Update(product);
        _unitOfWork._customerRepository.Update(client);
        _unitOfWork._orderRepository.Insert(order);
        await _unitOfWork.Commit();
        var orderDto = _mapper.Map<OrderDTO>(order);
        return orderDto;
    }
}
