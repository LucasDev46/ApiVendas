using Loja.Context;
using Loja.Repository.Interface;

namespace Loja.Repository;

public class UnitOfWork : IUnitOfWork
{
    public CategoryRepository categoryRepository { get; set; }
    public ProductRepository productRepository { get; set; }
    public CustomerRepository customerRepository { get; set; }
    public OrderRepository orderRepository { get; set; }
    public AppDbContext _context { get; set; }
    public ProductOrderRepository productOrderRepository { get; set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public ICustomerRepository _customerRepository
    {
        get
        {
            return customerRepository = customerRepository ?? new CustomerRepository(_context);
        }
    }
    public ICategoryRepository _categoryRepository
    {
        get
        {

            return categoryRepository = categoryRepository ?? new CategoryRepository(_context);
        }
    }

    public IProductRepository _productRepository
    {
        get
        {
            return productRepository = productRepository ?? new ProductRepository(_context);
        }
    }

    public IOrderRepository _orderRepository
    {
        get
        {
            return orderRepository = orderRepository ?? new OrderRepository(_context);
        }
    }

    public IProductOrderRepository _productOrderRepository
    {
        get
        {
            return productOrderRepository = productOrderRepository ?? new ProductOrderRepository(_context);
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
