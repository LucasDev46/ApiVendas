namespace Loja.Repository.Interface;

public interface IUnitOfWork
{
    ICategoryRepository _categoryRepository { get; }
    IProductRepository _productRepository { get; }
    IClientRepository _clientRepository { get; }
    IOrderRepository _orderRepository { get; }
    Task Commit();
}
