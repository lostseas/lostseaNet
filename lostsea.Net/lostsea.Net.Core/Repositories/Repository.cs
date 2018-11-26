using lostsea.Net.EntityFramework;
using lostsea.Net.EntityFramework.BaseData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.Core.Repositories
{

    public class Repository<TEntity> : Repository<TEntity, int>, IRepository<TEntity> where TEntity : Entity<int>, new()
    {
    }

    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>, new() where TPrimaryKey : struct
    {

        private readonly DBContext _context;

        public Repository()
        {
            _context = ContextConfig.CreateContext();
        }


        #region 新增

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public TEntity AddEntity(TEntity t)
        {
            var model = _context.Set<TEntity>().Add(t);
            _context.SaveChanges();
            return model;
        }
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<TEntity> AddEntityAsync(TEntity t)
        {
            var model = Task.Run<TEntity>(() => _context.Set<TEntity>().Add(t));
            _context.SaveChangesAsync();
            return model;
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int AddRange(IEnumerable<TEntity> list)
        {
            _context.Set<TEntity>().AddRange(list);
            return _context.SaveChanges();
        }
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public Task<int> AddRangeAsync(IEnumerable<TEntity> list)
        {
            _context.Set<TEntity>().AddRange(list);
            return _context.SaveChangesAsync();
        }
        #endregion

        #region 查询
        public TEntity GetEntityById(TPrimaryKey id)
        {
            return GetDbSet().Find(id);
        }

        /// <summary>
        /// 获得所有
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetList<TKey>(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TKey>> orderLambda)
        {
            if (whereLambda == null && orderLambda == null)
            {
                return GetData();
            }
            if (whereLambda == null)
            {
                return GetData().OrderBy(orderLambda);
            }
            if (orderLambda == null)
            {
                return GetData().Where(whereLambda);
            }
            return GetData().Where(whereLambda).OrderBy(orderLambda);
        }

        /// <summary>
        /// 获得所有
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda)
        {
            if (whereLambda == null)
            {
                return GetData();
            }
            return GetData().Where(whereLambda);
        }
        /// <summary>
        /// 获得所有
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetList()
        {
            return GetData();
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="pageiIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetList<TKey>(Expression<Func<TEntity, bool>> whereLambda = null, Expression<Func<TEntity, TKey>> orderLambda = null, int pageiIndex = 1, int pageSize = 10)
        {
            var query = GetList(whereLambda, orderLambda);
            var totalCount = query.Count();
            return query.Skip((pageiIndex - 1) * pageSize).Take(pageSize);
        }
        #endregion

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual int UpdateEntity(TEntity t)
        {
            _context.Set<TEntity>().Attach(t);
            return _context.SaveChanges();
        }

        /// <summary>
        /// 获得更新的数量
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual Task<int> UpdateEntityAsync(TEntity t)
        {
            _context.Set<TEntity>().Attach(t);

            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual int UpdateRanage(IList<TEntity> list)
        {
            _context.Set<TEntity>().AddOrUpdate(list.ToArray());
            return _context.SaveChanges();
        }


        /// <summary>
        /// 根据条件更新数据
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        /// <param name="updateLambda">更新表达式</param>
        /// <returns></returns>
        public virtual int Update(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TEntity>> updateLambda)
        {

            var data = _context.Set<TEntity>().Where(whereLambda);
            Type t = typeof(TEntity);
            List<string> proInfos = t.GetProperties().Select(o => o.Name).ToList();
            MemberInitExpression memberInitExpression = updateLambda.Body as MemberInitExpression;
            if (memberInitExpression == null)
            {
                throw new ArgumentException("The update expression must be of type MemberInitExpression.", "updateLambda");
            }
            foreach (MemberBinding current in memberInitExpression.Bindings)
            {
                string propertyName = current.Member.Name;

                MemberAssignment memberAssignment = current as MemberAssignment;
                if (memberAssignment == null)
                    throw new ArgumentException("memberAssignment is null", "updateLambda");

                Expression expression = memberAssignment.Expression;
                ConstantExpression constantExpression = expression as ConstantExpression;
                if (constantExpression == null)
                    throw new ArgumentException("constantExpression is null", "updateLambda");
                //new System.Linq.Expressions.Expression.MemberExpressionProxy(expression).Expression
                var value = constantExpression.Value;
                if (proInfos.Exists(p => p.Contains(propertyName)))
                {
                    _context.Entry(data).Property(propertyName).CurrentValue = value;
                    _context.Entry(data).Property(propertyName).IsModified = true;
                }
            }
            return _context.SaveChanges();
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public int Delete(TPrimaryKey Id, bool isDel = false)
        {
            var model = GetDbSet().Find(Id);
            if (model == null)
            {
                throw new ArgumentException("this model not exits", "ID");

            }
            if (isDel)
            {
                _context.Set<TEntity>().Remove(model);
            }
            else
            {
                model.IsDeleted = true;
                UpdateEntity(model);
            }
            return _context.SaveChanges();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public virtual int DeleteRange(IList<TPrimaryKey> idList, bool isDel = false)
        {
            foreach (var item in idList)
            {
                var model = GetDbSet().Find(item);
                if (model == null)
                {
                    throw new ArgumentException("this model not exits", "ID");

                }
                if (isDel)
                {
                    _context.Set<TEntity>().Remove(model);
                }
                else
                {
                    model.IsDeleted = true;
                    UpdateEntity(model);
                }
            }
            return _context.SaveChanges();
        }

        public virtual int DeleteRange(Expression<Func<TEntity, bool>> whereLambda, bool isDel = false)
        {
            var list = GetData().Where(whereLambda);
            if (isDel)
            {
                _context.Set<TEntity>().RemoveRange(list);
                return _context.SaveChanges();
            }
            else
            {
                return Update(whereLambda, t => new TEntity() { IsDeleted = true });
            }
        }
        #endregion


        /// <summary>
        /// 获得所有数据
        /// </summary>
        /// <returns></returns>
        private IQueryable<TEntity> GetData()
        {
            return GetDbSet().Where(t => !t.IsDeleted);
        }

        /// <summary>
        /// 获得DbSet
        /// </summary>
        /// <returns></returns>
        private DbSet<TEntity> GetDbSet()
        {
            return _context.Set<TEntity>();
        }
    }

}
