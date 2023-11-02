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
        var orders = await _unitOfWork._orderRepository.SelectAllOrder();
        if (orders is null)
        {
            return null;
        }
        var ordersDto = _mapper.Map<List<OrderDTO>>(orders);
        return ordersDto;
    }

    public async Task<OrderDTO> GetOrderById(long id)
    {
        var order = await _unitOfWork._orderRepository.SelectAll().Include(p => p.Customer).Include(o => o.ProductOrder).FirstOrDefaultAsync(p => p.OrderId == id);
        if (order is null)
        {
            return null;
        }

        var orderDto = _mapper.Map<OrderDTO>(order);
        return orderDto;
    }

    public async Task<OrderDTO> CreateOrder(OrderDTO order)
    {
        var entity = _mapper.Map<Order>(order);
        if (entity is null)
        {
            return null;
        }
        foreach (var item in order.ProductOrder)
        {
            var product = await _unitOfWork._productRepository.SelectByQuery(p => p.ProductId == item.ProductId);
            entity.TotalValue += product.Price * item.Quantity;
            product.stock -= item.Quantity;
            _unitOfWork._productRepository.Update(product);
        }

        _unitOfWork._orderRepository.Insert(entity);
        await _unitOfWork.Commit();
        return order;
    }
}
