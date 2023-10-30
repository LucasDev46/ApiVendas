using Loja.Context;
using Loja.Models;
using Loja.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context)
        {
        }
    }
}
