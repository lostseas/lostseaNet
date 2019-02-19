using lostsea.Net.EntityFramework.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.EntityFramework.Entities
{
    /// <summary>
    /// token 生成记录
    /// </summary>
    public class Tsys_AuthTokenRecord : Entity
    {
        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }
        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; }
        /// <summary>
        /// 生成Token
        /// </summary>
        public string AccessToken { get; set; }
    }
}
