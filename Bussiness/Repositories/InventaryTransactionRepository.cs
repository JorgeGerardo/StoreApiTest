using Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Repositories
{
    internal class InventaryTransactionRepository : GenericRepository<InventaryTransaction>
    {
        public InventaryTransactionRepository(DbContext context) : base(context) { }
    }
}
