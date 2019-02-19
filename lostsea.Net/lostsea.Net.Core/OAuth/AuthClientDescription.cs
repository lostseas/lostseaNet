using DotNetOpenAuth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.Core.OAuth
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthClientDescription : IClientDescription
    {

        /// <summary>
        /// 客户端id
        /// </summary>
        public string ClientId { get; set; }

       /// <summary>
       /// 回调地址
       /// </summary>
        public Uri CallBack { get; set; }


        public Uri DefaultCallback => throw new NotImplementedException();

        public ClientType ClientType => throw new NotImplementedException();

        public bool HasNonEmptySecret => throw new NotImplementedException();

        public bool IsCallbackAllowed(Uri callback)
        {

            throw new NotImplementedException();
        }

        public bool IsValidClientSecret(string secret)
        {
            throw new NotImplementedException();
        }
    }
}
