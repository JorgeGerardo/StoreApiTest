using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class StoreInventaryController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repositoryProduct;
        private readonly IGenericRepository<Store> _repositoryStore;

        public StoreInventaryController(IGenericRepository<Product> _repositoryProduct, IGenericRepository<Store> _repositoryStore)
        {
            this._repositoryProduct = _repositoryProduct;
            this._repositoryStore = _repositoryStore;
        }
    }

    public partial class StoreInventaryController
    {
        //Update stock
    }
}
