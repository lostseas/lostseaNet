using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.Core.OAuth
{
    /// <summary>
    /// 认证服务端配置信息
    /// </summary>
    public class AuthorizationServerConfig
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AuthorizationServerConfig()
        {
            TokenLifetime = TimeSpan.FromHours(2);
        }

        /// <summary>
        /// 签名证书
        /// </summary>
        public X509Certificate2 SigningCertificate { get; set; }

        /// <summary>
        /// 加密证书
        /// </summary>
        public X509Certificate2 EncryptionCertificate { get; set; }

        /// <summary>
        /// Token有效时间
        /// </summary>
        public TimeSpan TokenLifetime { get; set; }
    }
}
