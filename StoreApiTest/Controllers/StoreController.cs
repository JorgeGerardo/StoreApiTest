using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace StoreApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : GenericController<Store, StoreRepository, StoreCreateDto, StoreUpdateDto>
    {
        public StoreController(IGenericRepository<Store> reposotory) : base(reposotory) { }

        protected override Store MapToEntity(StoreCreateDto dto) =>
            new Store
            {
                Address = dto.Address,
                Sucursal = dto.Sucursal,
            };

        protected override Store MapToUpdateEntity(Store currentState, StoreUpdateDto dto)
        {
            currentState.Address = dto.Address;
            currentState.Sucursal = dto.Sucursal;
            return currentState;
        }
    }
}
