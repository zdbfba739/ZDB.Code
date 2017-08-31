using System;

namespace ZDB.GenerateUniqueID
{
    public class MadeUniqueID
    {
        /// <summary>
        /// 根据GUID获取16位的唯一字符串
        /// Author  : 付义方  
        /// </summary>
        /// <returns></returns>
        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int) b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        /// <summary>
        /// 根据GUID获取19位的唯一数字序列
        /// Author  : 付义方  
        /// </summary>
        /// <returns></returns>
        public static long GuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 生成22位唯一的数字 并发可用
        /// Author  : 付义方  
        /// </summary>
        /// <returns></returns>
        public static string GenerateUniqueID()
        {
            System.Threading.Thread.Sleep(1); //保证yyyyMMddHHmmssffff唯一
            Random d = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
            string strUnique = DateTime.Now.ToString("yyyyMMddHHmmssffff") + d.Next(1000, 9999);
            return strUnique;
        }
    }
}
