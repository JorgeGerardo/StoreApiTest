using Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> Create(T entity);

        IQueryable<T> GetAll();
        Task<T?> GetById(int id);
        Task<bool> Exist(int id);

        void Update(T entity);
        Task<bool> Delete(int id);


        Task<int> GetCount();
        Task<int> GetCountNoFiltters();


        Task<int> Save();
    }

    public  abstract partial class GenericRepository<T> : IGenericRepository<T> 
        where T : BaseModel
    {
        private readonly DbContext _context;
        protected DbSet<T> Entities => _context.Set<T>();

        protected GenericRepository(DbContext context) =>
            _context = context;

    }

    //CRUD:
    public abstract partial class GenericRepository<T>
    {
        public IQueryable<T> GetAll() => Entities;

        public async Task<T> Create(T entity) =>
            (await Entities.AddAsync(entity)).Entity;

        public async Task<bool> Exist(int id) =>
            await Entities.AnyAsync(e => e.Id == id);



        public Task<T?> GetById(int id) =>
            Entities.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<bool> Delete(int id)
        {
            T? res = await Entities.FirstOrDefaultAsync(e => e.Id == id);

            if (res is null)
                return false;

            Entities.Remove(res);
            return true;
        }

        public void Update(T entity) =>
            Entities.Update(entity);

    }

    //Tools:
    public abstract partial class GenericRepository<T>
    {
        public Task<int> GetCount() =>
            Entities.CountAsync();

        public Task<int> GetCountNoFiltters() =>
            Entities.IgnoreQueryFilters().CountAsync();

        public async Task<int> Save() =>
            await _context.SaveChangesAsync();
    }
}
