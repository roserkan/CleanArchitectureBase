using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>, IRepository<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
    protected TContext Context { get; }

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    #region GetMethods
    public TEntity Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true)
    {
        var query = Context.Set<TEntity>().AsQueryable();
        if (!enableTracking) query = query.AsNoTracking();
        if (include != null)
        if (include != null) query = include(query);
        return query.FirstOrDefault(predicate);
    }
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true)
    {
        var query = Context.Set<TEntity>().AsQueryable();
        if (!enableTracking) query = query.AsNoTracking();
        if (include != null) query = include(query);
        return await query.FirstOrDefaultAsync(predicate);
    }
    #endregion GetMethods

    #region GetListMethods
    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, 
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
                                bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return orderBy(queryable).ToList();
        return queryable.ToList();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, 
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
                                           bool enableTracking = true, 
                                           CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToListAsync(cancellationToken);
        return await queryable.ToListAsync(cancellationToken);
    }

    public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                      int index = 0, int size = 10,
                                      bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return orderBy(queryable).ToPaginate(index, size);
        return queryable.ToPaginate(index, size);
    }

    public IPaginate<TEntity> GetListByDynamic(Dynamic.Dynamic dynamic,
                                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                   include = null, int index = 0, int size = 10,
                                               bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return queryable.ToPaginate(index, size);
    }

    public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                           null,
                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                           include = null,
                                                       int index = 0, int size = 10, bool enableTracking = true,
                                                       CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }


    public async Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
                                                                Func<IQueryable<TEntity>,
                                                                        IIncludableQueryable<TEntity, object>>?
                                                                    include = null,
                                                                int index = 0, int size = 10,
                                                                bool enableTracking = true,
                                                                CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }
    #endregion

    #region InsertMethods
    public TEntity Add(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
        return entity;
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }
    #endregion

    #region UpdateMethods
    public TEntity Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }
    #endregion

    #region DeleteMethods
    public TEntity Delete(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        Context.SaveChanges();
        return entity;
    }
    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var x = Context.ChangeTracker.Entries();
        Context.Entry(entity).State = EntityState.Deleted;
        await Context.SaveChangesAsync();
        return entity;
    }
    #endregion

    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }
}