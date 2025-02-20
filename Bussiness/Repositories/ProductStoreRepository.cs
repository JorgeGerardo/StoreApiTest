using Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Repositories
{
    internal class ProductStoreRepository : GenericRepository<StoreInventary>
    {
        public ProductStoreRepository(DbContext context) : base(context) { }
    }
}
