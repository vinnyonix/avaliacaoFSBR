using AvaliacaoMVCValnei.App.Service.Interfaces;
using AvaliacaoMVCValnei.Data.Interfaces;
using AvaliacaoMVCValnei.Data.Entities;
using System.Linq.Expressions;

namespace AvaliacaoMVCValnei.App.Service
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _processRepository;

        public ProcessService(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }
        public void Add(ProcessEntity entity)
        {
            _processRepository.Add(entity);
        }

        public async Task AddAsync(ProcessEntity entity)
        {
            await _processRepository.AddAsync(entity);
        }

        public void Delete(ProcessEntity entity)
        {
            _processRepository.Delete(entity);
        }

        public async Task DeleteAsync(ProcessEntity entity)
        {
            await _processRepository.DeleteAsync(entity);
        }

        public async Task<ProcessEntity?> FindAsync(Expression<Func<ProcessEntity, bool>> predicate)
        {
            return await _processRepository.FindAsync(predicate);
        }

        public void Insert(ProcessEntity entity)
        {
            _processRepository.Insert(entity);
        }

        public async Task InsertAsync(ProcessEntity entity)
        {
            await _processRepository.InsertAsync(entity);
        }

        public async Task<IList<ProcessEntity>> ListAsync()
        {
            return await _processRepository.ListAsync();
        }

        public async Task<IList<ProcessEntity>> ListAsync(Expression<Func<ProcessEntity, bool>> predicate)
        {
            return await _processRepository.ListAsync(predicate);
        }

        public IQueryable<ProcessEntity> Query()
        {
            return _processRepository.Query();
        }

        public IQueryable<ProcessEntity> Query(Expression<Func<ProcessEntity, bool>> predicate)
        {
            return _processRepository.Query(predicate);
        }

        public void SaveChanges()
        {
            _processRepository.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _processRepository.SaveChangesAsync();
        }

        public void Update(ProcessEntity entity)
        {
            _processRepository.Update(entity);
        }

        public async Task UpdateAsync(ProcessEntity entity)
        {
            await _processRepository.UpdateAsync(entity);
        }
    }
}
