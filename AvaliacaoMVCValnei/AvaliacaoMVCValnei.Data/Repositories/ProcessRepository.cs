using AvaliacaoMVCValnei.Data.Interfaces;
using AvaliacaoMVCValnei.Data.Entities;
using AvaliacaoMVCValnei.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AvaliacaoMVCValnei.Data.Repositories
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly AppDbContext _context;

        public ProcessRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(ProcessEntity entity)
        {
            _context.Set<ProcessEntity>().Add(entity);
        }

        public async Task AddAsync(ProcessEntity entity)
        {
            await _context.Set<ProcessEntity>().AddAsync(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task InsertAsync(ProcessEntity entity)
        {
            await _context.Set<ProcessEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Insert(ProcessEntity entity)
        {
            _context.Set<ProcessEntity>().Add(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(ProcessEntity entity)
        {
            _context.Set<ProcessEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(ProcessEntity entity)
        {
            _context.Set<ProcessEntity>().Update(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(ProcessEntity entity)
        {
            _context.Set<ProcessEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(ProcessEntity entity)
        {
            _context.Set<ProcessEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task<ProcessEntity?> FindAsync(Expression<Func<ProcessEntity, bool>> predicate)
        {
            return await _context.Set<ProcessEntity>()
                .Where(predicate)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<ProcessEntity>> ListAsync()
        {
            return await _context.Set<ProcessEntity>().ToListAsync();
        }

        public async Task<IList<ProcessEntity>> ListAsync(Expression<Func<ProcessEntity, bool>> predicate)
        {
            return await _context.Set<ProcessEntity>()
                .Where(predicate)
                .ToListAsync();
        }

        public IQueryable<ProcessEntity> Query()
        {
            return _context.Set<ProcessEntity>().AsQueryable();
        }

        public IQueryable<ProcessEntity> Query(Expression<Func<ProcessEntity, bool>> predicate)
        {
            return _context.Set<ProcessEntity>()
                .Where(predicate)
                .AsQueryable();
        }
    }
}
