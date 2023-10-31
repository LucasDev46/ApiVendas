using Loja.Context;
using Loja.Models;
using Loja.Repository.Interface;

namespace Loja.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
