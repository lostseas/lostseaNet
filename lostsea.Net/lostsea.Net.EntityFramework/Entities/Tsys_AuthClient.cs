using lostsea.Net.EntityFramework.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.EntityFramework.Entities
{
    /// <summary>
    /// 认证客户信息
    /// </summary>
    public class Tsys_AuthClient : Entity
    {
        /// <summary>  
    	/// 客户端标识  
    	/// </summary>  
        public string ClientId { get; set; }
        /// <summary>  
        /// 客户端密码  
        /// </summary>  
        public string ClinentSercet { get; set; }
        /// <summary>  
        /// 客户端验证类型 0:身份验证 1:公开验证  
        /// </summary>  
        public int ClientAuthType { get; set; }
        /// <summary>  
        /// 客户端名称  
        /// </summary>  
        public string ClientName { get; set; }
        /// <summary>  
        /// 客户端访问范围  
        /// </summary>  
        public string Scope { get; set; }
        /// <summary>  
        /// 系统代码 0 所有系统
        /// </summary>  
        public string SystemCode { get; set; }
        /// <summary>  
        /// 客户端回调地址  
        /// </summary>  
        public string Callback { get; set; }

    }
}
