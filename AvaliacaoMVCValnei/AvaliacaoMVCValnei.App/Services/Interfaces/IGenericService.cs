using System.Linq.Expressions;

namespace AvaliacaoMVCValnei.App.Services.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void SaveChanges();
        Task SaveChangesAsync();
        Task InsertAsync(TEntity entity);
        void Insert(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> ListAsync();
        Task<IList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
    }
}

