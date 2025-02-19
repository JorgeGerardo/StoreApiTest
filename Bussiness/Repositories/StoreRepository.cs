using Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Repositories
{
    public class StoreRepository : GenericRepository<Store>
    {
        public StoreRepository(DbContext context) : base(context) { }
    }
}
