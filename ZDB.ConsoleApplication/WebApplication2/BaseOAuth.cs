using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;

namespace WebApplication2
{
    public abstract class BaseOAuth
    {
        public HttpRequest Request = HttpContext.Current.Request;
        public HttpResponse Response = HttpContext.Current.Response;
        public HttpSessionState Session = HttpContext.Current.Session;

        public abstract void Login();
        public abstract string Callback();

        #region 内部使用函数  

        /// <summary>  
        /// 生成唯一随机串防CSRF攻击  
        /// </summary>  
        /// <returns></returns>  
        protected string GetStateCode()
        {
            Random rand = new Random();
            string data = DateTime.Now.ToString("yyyyMMddHHmmssffff") + rand.Next(1, 0xf423f).ToString();

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] md5byte = md5.ComputeHash(UTF8Encoding.Default.GetBytes(data));

            return BitConverter.ToString(md5byte).Replace("-", "");

        }

        /// <summary>  
        /// GET请求  
        /// </summary>  
        /// <param name="url"></param>  
        /// <returns></returns>  
        protected string GetRequest(string url)
        {
            HttpWebRequest httpWebRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = "GET";
            httpWebRequest.ServicePoint.Expect100Continue = false;

            StreamReader responseReader = null;
            string responseData;
            try
            {
                responseReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            finally
            {
                httpWebRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
            }

            return responseData;
        }

        /// <summary>  
        /// POST请求  
        /// </summary>  
        /// <param name="url"></param>  
        /// <param name="postData"></param>  
        /// <returns></returns>  
        protected string PostRequest(string url, string postData)
        {
            HttpWebRequest httpWebRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ServicePoint.Expect100Continue = false;
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";

            //写入POST参数  
            StreamWriter requestWriter = new StreamWriter(httpWebRequest.GetRequestStream());
            try
            {
                requestWriter.Write(postData);
            }
            finally
            {
                requestWriter.Close();
            }

            //读取请求后的结果  
            StreamReader responseReader = null;
            string responseData;
            try
            {
                responseReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            finally
            {
                httpWebRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
            }

            return responseData;
        }

        /// <summary>  
        /// 解析JSON  
        /// </summary>  
        /// <param name="strJson"></param>  
        /// <returns></returns>  
        protected NameValueCollection ParseJson(string strJson)
        {
            NameValueCollection mc = new NameValueCollection();
            Regex regex = new Regex(@"(\s*\""?([^""]*)\""?\s*\:\s*\""?([^""]*)\""?\,?)");
            strJson = strJson.Trim();
            if (strJson.StartsWith("{"))
            {
                strJson = strJson.Substring(1, strJson.Length - 2);
            }

            foreach (Match m in regex.Matches(strJson))
            {
                mc.Add(m.Groups[2].Value, m.Groups[3].Value);
            }
            return mc;
        }

        /// <summary>  
        /// 解析URL  
        /// </summary>  
        /// <param name="strParams"></param>  
        /// <returns></returns>  
        protected NameValueCollection ParseUrlParameters(string strParams)
        {
            NameValueCollection nc = new NameValueCollection();
            foreach (string p in strParams.Split('&'))
            {
                string[] ps = p.Split('=');
                nc.Add(ps[0], ps[1]);
            }
            return nc;
        }

        #endregion
    }
}