using Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(DbContext context) : base(context) { }
    }
}
