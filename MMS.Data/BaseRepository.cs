using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Data
{
    internal class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;
        public BaseRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        #region 单体查询
        /// <summary>
        /// 根据ID查询单个实体
        /// </summary>
        public TEntity Find(object id)
        {
            return _dbSet.Find(id);
        }
        /// <summary>
        /// 根据条件查询单个实体
        /// </summary>
        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }
        #endregion

        #region 列表查询
        /// <summary>
        /// 查询所有实体
        /// </summary>
        public IQueryable<TEntity> FindList()
        {
            return _dbSet;
        }

        /// <summary>
        /// 查询符合条件的所有实体
        /// </summary>
        public IQueryable<TEntity> FindList(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        /// <summary>
        /// 查询排序实体列表
        /// </summary>
        /// <typeparam name="TOrder">排序列类型</typeparam>
        /// <param name="order">排序条件</param>
        /// <param name="asc">是否升序排列</param>
        public IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool asc)
        {
            return asc ? _dbSet.OrderBy(order):_dbSet.OrderByDescending(order);
        }

        /// <summary>
        /// 查询排序实体列表并取指定数量的实体
        /// </summary>
        /// <typeparam name="TOrder">排序列类型</typeparam>
        /// <param name="order">排序条件</param>
        /// <param name="asc">是否升序排列</param>
        /// <param name="number">获取实体数量</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool asc, int number)
        {
            return asc ? _dbSet.OrderBy(order).Take(number) : _dbSet.OrderByDescending(order).Take(number);
        }

        /// <summary>
        /// 按条件查询排序实体列表
        /// </summary>
        /// <typeparam name="TOrder">排序列类型</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <param name="order">排序条件</param>
        /// <param name="asc">是否升序排列</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool asc)
        {
            return asc ? _dbSet.Where(predicate).OrderBy(order) : _dbSet.Where(predicate).OrderByDescending(order);
        }

        /// <summary>
        /// 按条件查询排序实体列表并获取指定数量的实体
        /// </summary>
        /// <typeparam name="TOrder">排序键类型</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <param name="order">排序条件</param>
        /// <param name="asc">是否升序排列</param>
        /// <param name="number">获取实体数量</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool asc, int number)
        {
            return asc ? _dbSet.Where(predicate).OrderBy(order).Take(number) : _dbSet.Where(predicate).OrderByDescending(order).Take(number);
        }

        /// <summary>
        /// 按条件查询排列实体列表并获取分页后的实体
        /// </summary>
        /// <typeparam name="TOrder">排序列类型</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <param name="order">排序条件</param>
        /// <param name="asc">是否升序排列</param>
        /// <param name="pageSize">每页记录数量</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="totalCount">总记录数量</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindPageList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool asc, int pageSize, int pageIndex, out int totalCount)
        {
            pageSize = pageSize <= 0 ? 20 : pageSize;
            pageIndex= pageIndex <= 0 ? 1 : pageIndex;
            totalCount = _dbSet.Where(predicate).Count();
            return asc ? _dbSet.Where(predicate).OrderBy(order).Skip(pageSize * (pageIndex - 1)).Take(pageSize) : _dbSet.Where(predicate).OrderByDescending(order).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }

        public IQueryable<TEntity> FindPageList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool asc, int pageSize, int pageIndex, out int totalCount, string[] includeProperties)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 新增
        /// <summary>
        /// 增加单个实体
        /// </summary>
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        /// <summary>
        /// 批量增加实体
        /// </summary>
        public void Add(IEnumerable<TEntity> entities)
        {
            //_context.Configuration.AutoDetectChangesEnabled = false;
            _dbSet.AddRange(entities);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除单个实体
        /// </summary>
        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }
        /// <summary>
        /// 根据ID删除单个实体
        /// </summary>
        public void Delete(object id)
        {
            TEntity entity = _dbSet.Find(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="entities"></param>
        public void Delete(IEnumerable<TEntity> entities)
        {
            //TODO:是否需要先设置实体状态？关联到上下文？
            _dbSet.RemoveRange(entities);
        }
        /// <summary>
        /// 删除符合条件的实体
        /// </summary>
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _dbSet.Where(predicate);
            if (entities.Count() <= 0)
            {
                return;
            }
            else if (entities.Count() == 1)
            {
                Delete(entities.First());
            }
            else
            {
                Delete(entities);
            }
        }
        #endregion

        #region 编辑
        public void Edit(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;
        }
        #endregion

    }
}
