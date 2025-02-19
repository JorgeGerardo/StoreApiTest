using Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(DbContext context) : base(context) { }
    }
}
