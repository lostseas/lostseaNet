using lostsea.Net.EntityFramework.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.EntityFramework.Entities
{
    /// <summary>
    /// 认证token信息
    /// </summary>
    public class Tsys_AuthAccessToken : Entity
    {
        /// <summary>
        /// token
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// 客户端ID
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 用户名称ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 刷新token
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// 客户端访问范围
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// 过期时间 null 永不过期
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
    }
}
