using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : GenericController<Customer, CustomerRepository, CustomerCreateDTO, CustomerUpdateDTO>
    {
        public CustomerController(IGenericRepository<Customer> reposotory) : base(reposotory)
        {
            
        }

        protected override Customer MapToEntity(CustomerCreateDTO dto)
        {
            return new Customer
            {
                Address = dto.Address,
                LastName = dto.LastName,
                Name = dto.Name,
            };
            throw new NotImplementedException();
        }

        protected override Customer MapToUpdateEntity(Customer currentState, CustomerUpdateDTO dto)
        {
            currentState.Address = dto.Address;
            currentState.LastName = dto.LastName;
            currentState.Name = dto.Name;
            return currentState;
        }
    }
}
