using Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Repositories
{
    internal class StoreInventaryRepository : GenericRepository<StoreInventary>
    {
        public StoreInventaryRepository(DbContext context) : base(context) { }
    }
}
