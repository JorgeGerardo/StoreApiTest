using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class StoreInventaryController : GenericController<StoreInventary, StoreInventaryRepository, StoreInventaryCreateDTO, StoreInventaryUpdateDTO>
    {
        private readonly IGenericRepository<Product> _repositoryProduct;
        private readonly IGenericRepository<Store> _repositoryStore;
        private readonly IGenericRepository<StoreInventary> _repositoryStoreInventary;

        public StoreInventaryController(IGenericRepository<StoreInventary> reposotory, IGenericRepository<Product> _repositoryProduct, IGenericRepository<Store> _repositoryStore) : base(reposotory)
        {
            _repositoryStoreInventary = reposotory;
            this._repositoryProduct = _repositoryProduct;
            this._repositoryStore = _repositoryStore;
        }

        protected override StoreInventary MapToEntity(StoreInventaryCreateDTO dto) =>
            MapToEntityAsync(dto).GetAwaiter().GetResult();

        protected override async Task<StoreInventary> MapToEntityAsync(StoreInventaryCreateDTO dto)
        {
            await DependenciesExist(dto.ProductId, dto.StoreId);

            var existentInventoryLog = _repositoryStoreInventary.GetAll()
                .Any(t => t.ProductId == dto.ProductId);

            if (existentInventoryLog)
                throw new Exception("El registro ya existe, si desea agregar " +
                    "más productos, solamente acutalice el registro existente");

            return new StoreInventary
            {
                Stock = dto.Stock,
                ProductId = dto.ProductId,
                StoreId = dto.StoreId,
            };
        }

        private async Task DependenciesExist(int productId, int storeId)
        {
            bool existe = await _repositoryProduct.Exist(productId);
            if (!existe)
                throw new Exception("El producto no existe");

            bool storeExist = await _repositoryStore.Exist(storeId);
            if (!storeExist)
                throw new Exception("La tienda seleccionada no existe");
        }

        

        protected override StoreInventary MapToUpdateEntity(StoreInventary currentState, StoreInventaryUpdateDTO dto) =>
            MapToUpdateEntityAsync(currentState, dto).GetAwaiter().GetResult();

        protected override async Task<StoreInventary> MapToUpdateEntityAsync(StoreInventary currentState, StoreInventaryUpdateDTO dto)
        {
            await DependenciesExist(dto.ProductId, dto.StoreId);

            currentState.StoreId = dto.StoreId;
            currentState.Stock = dto.Stock;
            currentState.ProductId = dto.ProductId;


            return currentState;
        }

    }

}
