using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StoreApiTest.Controllers
{
    public abstract partial class GenericController<T, TRepository, TCreateDTO, TUpdateDTO> : ControllerBase
        where T : BaseModel
        where TRepository : IGenericRepository<T>
    {
        private readonly IGenericRepository<T> _repository;
        protected GenericController(IGenericRepository<T> reposotory) =>
            _repository = reposotory;

    }

    //Get's:
    public abstract partial class GenericController<T, TRepository, TCreateDTO, TUpdateDTO>
    {
        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get(int page = 0, int? pageSize = null) =>
            await setPagination(page, pageSize).ToListAsync();

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetById(int id)
        {
            T? res = await _repository.GetById(id);
            return res is not null ? res : NotFound();
        }
    }


    //CxUD (CRUD):
    public abstract partial class GenericController<T, TRepository, TCreateDTO, TUpdateDTO>
    {
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, TUpdateDTO createDto)
        {
            var entity = await _repository.GetById(id);
            if (entity is null)
                return NotFound();

            try { MapToUpdateEntity(entity, createDto); }
            catch (Exception e)
            {
                return BadRequest(new ProblemDetails() { Detail = e.Message });
            }

            _repository.Update(entity);
            await _repository.Save();

            return NoContent();
        }



        [HttpPost]
        public virtual async Task<IActionResult> Add(TCreateDTO createDto)
        {
            try
            {
                T newEntity = MapToEntity(createDto);
                await _repository.Create(newEntity);
                await _repository.Save();

                if (newEntity is null)
                    return StatusCode(500, new ProblemDetails { Detail = "Error creating entity." });

                return CreatedAtAction(nameof(GetById), new { newEntity.Id }, newEntity);
            }
            catch (Exception e)
            {
                return BadRequest(new ProblemDetails { Detail = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> HardDelete(int id)
        {
            bool isDeleted = await _repository.Delete(id);
            await _repository.Save();

            return isDeleted ? NoContent() : NotFound();
        }

    }


    //Maps:
    public abstract partial class GenericController<T, TRepository, TCreateDTO, TUpdateDTO>
    {
        protected abstract T MapToEntity(TCreateDTO dto);
        protected virtual Task<T> MapToEntityAsync(TCreateDTO dto) =>
            Task.FromResult(MapToEntity(dto));

        //Update
        protected abstract T MapToUpdateEntity(T currentState, TUpdateDTO dto);
        protected virtual Task<T> MapToUpdateEntityAsync(T currentState, TUpdateDTO dto) =>
            Task.FromResult(MapToUpdateEntity(currentState, dto));

    }

    public abstract partial class GenericController<T, TRepository, TCreateDTO, TUpdateDTO>
    {
        [HttpGet("count")]
        public async Task<int> count() =>
            await _repository.GetAll().CountAsync();
    }

    //Tools:
    public abstract partial class GenericController<T, TRepository, TCreateDTO, TUpdateDTO>
    {
        private const int DEFAULT_PAGE_SIZE = 10;
        private IQueryable<T> setPagination(int page, int? pageSize = null, IQueryable<T>? query = null)
        {
            page--;

            if (query is null)
                query = _repository.GetAll();

            query = query.Skip((pageSize ?? DEFAULT_PAGE_SIZE) * page);

            if (pageSize is not null)
                query = query.Take(pageSize.Value);

            return query;
        }
    }

}
