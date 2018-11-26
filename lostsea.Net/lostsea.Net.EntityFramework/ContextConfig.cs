using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.EntityFramework
{
    /// <summary>
    /// context 配置信息
    /// </summary>
    public class ContextConfig
    {
        public static DBContext CreateContext()
        {
            return new DBContext();
        }
    }
}
