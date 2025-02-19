using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : GenericController<Product, ProductRepository, ProductCreateDTO, ProductUpdateDTO>
    {
        public ProductController(IGenericRepository<Product> _repository) : base(_repository) { }
        protected override Product MapToEntity(ProductCreateDTO dto)
        {
            return new Product
            {
                Description = dto.Description,
                Image = dto.Image,
                Price = dto.Price,
                Title = dto.Title,
            };
        }

        protected override Product MapToUpdateEntity(Product currentState, ProductUpdateDTO dto)
        {
            currentState.Price = dto.Price;
            currentState.Title = dto.Title;
            currentState.Image = dto.Image;
            currentState.Description = dto.Description;
            return currentState;
        }
    }

}
