using Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Repositories
{
    public class CustomerProductRepository : GenericRepository<CustomerProduct>
    {
        public CustomerProductRepository(DbContext context) : base(context) { }
    }
}
