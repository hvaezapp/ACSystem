using ACSystem.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace ACSystem.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ACSystemDbContext _context;
        private readonly DbSet<T> _table;


        public GenericRepository(ACSystemDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }


        public virtual async Task<T> Create(T entity, CancellationToken cancellationToken)
        {
            try
            {
                await _table.AddAsync(entity, cancellationToken);
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task Update(T entity)
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _table.Attach(entity);
                }
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task Delete(T entity)
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _table.Attach(entity);
                }
                _table.Remove(entity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task<T> GetByIdAsync(object Id, CancellationToken cancellationToken)
        {
            try
            {
                return await _table.FindAsync(Id, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
        {
            return await _table.Where(where).AsNoTracking().ToListAsync(cancellationToken);
        }


        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
        {
            return  _table.Where(where).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsyncWithPaging(Expression<Func<T, bool>> where , int skip , int take ,  CancellationToken cancellationToken)
        {

            IQueryable<T> query = _table;

            if (where != null)
            {
                query = query.Where(where);
            }


            return await query.AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);

            //return await _table.Where(where).AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsyncWithPaging(Expression<Func<T, bool>> where, int skip, int take, string join , CancellationToken cancellationToken)
        {
            IQueryable<T> query = _table;

            if (where != null)
            {
                query = query.Where(where);
            }

            //join

            if (!string.IsNullOrEmpty(join))
            {
                foreach (string joins in join.Split(','))
                {
                    query = query.Include(joins);
                }
            }

            return await query.AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);
        }


        public async Task<IEnumerable<T>> GetAllAsyncWithPaging(int skip, int take, CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);
        }



        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> where, Func<IQueryable<T>,
           IOrderedQueryable<T>> orderbyVariable, string joinString, CancellationToken cancellationToken)
        {

            IQueryable<T> query = _table;

            //where cond
            if (where != null)
            {
                query = query.Where(where);
            }

            //order

            if (orderbyVariable != null)
            {
                query = orderbyVariable(query);
            }


            //join

            if (!string.IsNullOrEmpty(joinString))
            {
                foreach (string joins in joinString.Split(','))
                {
                    query = query.Include(joins);
                }
            }

            return await query.AsNoTracking().ToListAsync(cancellationToken);

        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
        {
            if (where != null)
                return await _table.Where(where).FirstOrDefaultAsync(cancellationToken);
            return await _table.FirstOrDefaultAsync(cancellationToken);
        }


    


        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> where, string joinstring, CancellationToken cancellationToken)
        {

            IQueryable<T> query = _table;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (!string.IsNullOrEmpty(joinstring))
            {
                foreach (var item in joinstring.Split(','))
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }




        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }





        #region Dispose


        protected bool isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                _context.Dispose();
            }

            isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
        #endregion

    }
}
