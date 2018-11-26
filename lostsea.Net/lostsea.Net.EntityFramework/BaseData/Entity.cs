using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.EntityFramework.BaseData
{
    /// <summary>
    /// 基础实体模型
    /// </summary>
    [Serializable]
    public abstract class Entity : Entity<int>, IEntity, IEntity<int>
    {

    }
    [Serializable]
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id
        {
            get;
            set;
        }

        public virtual DateTime CreatedTime { get; set; }

        public virtual DateTime UpdatedTime { get; set; }

        public virtual bool IsDeleted { get; set; }
    }
}
