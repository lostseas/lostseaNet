using lostsea.Net.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.EntityFramework
{
    /// <summary>
    /// 数据上下文
    /// </summary>
    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=SqlConnection")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<Tsys_AuthClient> Tsys_AuthClient { get; set; }
    }
}
