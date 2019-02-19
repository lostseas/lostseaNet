using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lostsea.Net.Common.Xml
{
    /// <summary>
    /// xml配置类
    /// </summary>
    public static class XmlHelpter
    {

        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        /// <summary>
        /// 读取属性值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public static string GetValueByKey(string key)
        {
            string value = null;
            try
            {
                if (config.AppSettings.Settings[key] != null)
                    value = config.AppSettings.Settings[key].Value;
            }
            catch (Exception ex)
            {
                throw new Exception("key不存在");
            }

            return value;
        }

        /// <summary>
        /// 写入值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        public static void SetValue(string key, string value)
        {
            try
            {
                if (config.AppSettings.Settings[key] != null)
                {
                    config.AppSettings.Settings[key].Value = value
                }
                else
                {
                    config.AppSettings.Settings.Add(key, value);
                }
            }
            catch (Exception)
            {

                throw new Exception("xml写入失败");
            }
        }

    }
}
