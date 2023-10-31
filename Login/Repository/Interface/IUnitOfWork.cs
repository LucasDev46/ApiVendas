namespace Loja.Repository.Interface;

public interface IUnitOfWork
{
    ICategoryRepository _categoryRepository { get; }
    IProductRepository _productRepository { get; }
    ICustomerRepository _customerRepository { get; }
    IOrderRepository _orderRepository { get; }
    Task Commit();
}
