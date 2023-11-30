using System.Linq.Expressions;

namespace ACSystem.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T entity, CancellationToken cancellationToken);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetByIdAsync(object Id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsyncWithPaging(Expression<Func<T, bool>> where, 
                                                            int skip, int take, 
                                                            CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsyncWithPaging(int skip, int take, 
                                                    CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsyncWithPaging(Expression<Func<T, bool>> where, 
                                                    int skip, int take, string join, 
                                                    CancellationToken cancellationToken);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> where, Func<IQueryable<T>,
                                                IOrderedQueryable<T>> orderbyVariable, 
                                                  string joinString, CancellationToken cancellationToken);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, 
                                        CancellationToken cancellationToken);

        
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where, CancellationToken cancellationToken);
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
