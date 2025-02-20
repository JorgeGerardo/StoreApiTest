using Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Repositories
{
    public class StoreInventaryRepository : GenericRepository<StoreInventary>
    {
        public StoreInventaryRepository(DbContext context) : base(context) { }
    }
}
