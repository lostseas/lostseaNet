using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.Core.Repositories
{
    public interface IRepository<TEntity> : IRepository<TEntity, int>
    {
    }

    public interface IRepository<TEntity, TPrimaryKey>
    {
        #region 新增

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        TEntity AddEntity(TEntity t);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<TEntity> AddEntityAsync(TEntity t);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int AddRange(IEnumerable<TEntity> list);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<int> AddRangeAsync(IEnumerable<TEntity> list);
        #endregion

        #region 查询

        TEntity GetEntityById(TPrimaryKey id);

        /// <summary>
        /// 获得所有
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetList<TKey>(Expression<Func<TEntity, bool>> whereLambda,
          Expression<Func<TEntity, TKey>> orderLambda);

        /// <summary>
        /// 获得所有
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda);

        /// <summary>
        /// 获得所有
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetList();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="pageiIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetList<TKey>(Expression<Func<TEntity, bool>> whereLambda = null,
          Expression<Func<TEntity, TKey>> orderLambda = null, int pageiIndex = 1, int pageSize = 10);
        #endregion

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int UpdateEntity(TEntity t);

        /// <summary>
        /// 获得更新的数量
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> UpdateEntityAsync(TEntity t);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int UpdateRanage(IList<TEntity> list);


        /// <summary>
        /// 根据条件更新数据
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        /// <param name="updateLambda">更新表达式</param>
        /// <returns></returns>
        int Update(Expression<Func<TEntity, bool>> whereLambda,
        Expression<Func<TEntity, TEntity>> updateLambda);
        #endregion

        #region 删除

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="isDel"></param>
        /// <returns></returns>
        int Delete(TPrimaryKey Id, bool isDel = false);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="isDel"></param>
        /// <returns></returns>
        int DeleteRange(IList<TPrimaryKey> idList, bool isDel = false);

        int DeleteRange(Expression<Func<TEntity, bool>> whereLambda, bool isDel = false);

        #endregion
    }
}
