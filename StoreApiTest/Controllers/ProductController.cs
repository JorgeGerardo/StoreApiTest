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

        [HttpGet]
        public async Task test()
        {
            var p = new Product { Description = "", Image = "url...", Price = 300, Stock = 40 };
            await _repository.Create(p);
            await _repository.Save();
        }

        [HttpGet("otro/{id}")]
        public async Task<Product?> get(int id)
        {
            return await this._repository.GetById(id);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
            await _repository.Save();
        }

        [HttpPut("{id}")]
        public async Task Update(int id)
        {
            var p = await _repository.GetById(id);

            if (p is not null)
            {
                p.Price = 9999;
                _repository.Update(p);
                await _repository.Save();
            }

        }

    }
}
