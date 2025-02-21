using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Customer> _CustomerRepository;
        private readonly IGenericRepository<User> _UserRepository;
        private readonly IGenericRepository<CustomerProduct> _CustomerProductRepository;
        public SaleController(IGenericRepository<Customer> customerRepository, IGenericRepository<Product> productRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<CustomerProduct> CustomerProductRepository)
        {
            _CustomerRepository = customerRepository;
            _UserRepository = userRepository;
            _productRepository = productRepository;
            _CustomerProductRepository = CustomerProductRepository;
        }


        [HttpPost, Authorize]
        public async Task<ActionResult> AddSale(List<ProductCartItem> cartItems)
        {
            if (!(Int32.TryParse(HttpContext.User?.Identity?.Name, out int UserId)))
                return StatusCode(500);

            var user = await _UserRepository.GetById(UserId);
            if (user is null)
                return BadRequest();

            if (user.CustomerId is null)
                return BadRequest();

            var customer = await _CustomerRepository.GetById(user.CustomerId.Value);
            if (customer is null)
                return BadRequest();

            foreach (var product in cartItems)
            {
                if (!(await _productRepository.Exist(product.Id)))
                    return BadRequest(new ProblemDetails { Detail = "El producto no existe" });

                var newTransaction = new CustomerProduct
                {
                    Date = DateTime.Now,
                    ProductId = product.Id,
                    CustomerId = customer.Id,
                    Quantity = product.Quantity,
                };

                await _CustomerProductRepository.Create(newTransaction);
            }


            await _CustomerProductRepository.Save();
            return Ok();

        }
    }
}
