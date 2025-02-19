using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repository;
        public ProductController(IGenericRepository<Product> _repository) =>
            this._repository = _repository;


    }
}
