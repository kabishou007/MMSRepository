using System;
using System.Collections.Generic;
using System.Linq;
using MMS.Core;
using System.Linq.Expressions;

namespace MMS.Data
{
    public interface IRepository<TEntity>:IDependency where TEntity:class
    {
        #region 单体查询
        TEntity Find(object id);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region 列表查询
        IQueryable<TEntity> FindList();
        IQueryable<TEntity> FindList(Expression<Func<TEntity, bool>> predicate);
        //IQueryable<TEntity> FindList(Expression<Func<TEntity, bool>> predicate,int number);

        IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool asc);
        IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool asc, int number);
       
        IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool asc);
        IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool asc, int number);


        IQueryable<TEntity> FindPageList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool asc,int pageSize,int pageIndex,out int totalCount);
        IQueryable<TEntity> FindPageList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool asc, int pageSize, int pageIndex, out int totalCount, string[] includeProperties);
        #endregion

        //IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter=null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy=null, string includePropertied="");

        #region 新增
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        #endregion

        #region 删除
        void Delete(object id);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region 编辑
        void Edit(TEntity entity);
        //int Edit(TEntity entity, string[] targetProperties);
        #endregion
    }
}
