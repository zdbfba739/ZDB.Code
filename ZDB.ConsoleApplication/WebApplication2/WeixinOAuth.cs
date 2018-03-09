using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class WeixinOAuth: BaseOAuth
    {
        public string AppId = ConfigurationManager.AppSettings["OAuth_Weixin_AppId"];
        public string AppSecret = ConfigurationManager.AppSettings["OAuth_Weixin_AppSecret"];
        public string RedirectUrl = ConfigurationManager.AppSettings["OAuth_Weixin_RedirectUrl"];

        public const string GET_AUTH_CODE_URL = "https://open.weixin.qq.com/connect/qrconnect";
        public const string GET_ACCESS_TOKEN_URL = "https://api.weixin.qq.com/sns/oauth2/access_token";
        public const string GET_USERINFO_URL = "https://api.weixin.qq.com/sns/userinfo";

        /// <summary>  
        /// 微信登录，跳转到登录页面  
        /// </summary>  
        public override void Login()
        {
            //-------生成唯一随机串防CSRF攻击  
            string state = GetStateCode();
            Session["Weixin_State"] = state; //state 放入Session  

            string parms = "?appid=" + AppId
                + "&redirect_uri=" + Uri.EscapeDataString(RedirectUrl) + "&response_type=code&scope=snsapi_login"
                + "&state=" + state + "#wechat_redirect";

            string url = GET_AUTH_CODE_URL + parms;
            Response.Redirect(url); //跳转到登录页面  
        }

        /// <summary>  
        /// 微信回调函数  
        /// </summary>  
        /// <param name="code"></param>  
        /// <param name="state"></param>  
        /// <returns></returns>  
        public override string Callback()
        {
            string code = Request.QueryString["code"];
            string state = Request.QueryString["state"];

            //--------验证state防止CSRF攻击  
            if (state != (string)Session["Weixin_State"])
            {
                ShowError("30001");
            }

            string parms = "?appid=" + AppId + "&secret=" + AppSecret
                + "&code=" + code + "&grant_type=authorization_code";

            string url = GET_ACCESS_TOKEN_URL + parms;
            string str = GetRequest(url);


            NameValueCollection msg = ParseJson(str);
            if (!string.IsNullOrEmpty(msg["errcode"]))
            {
                ShowError(msg["errcode"], msg["errmsg"]);
            }

            Session["Weixin_AccessToken"] = msg["access_token"]; //access_token 放入Session  
            Session["Weixin_OpenId"] = msg["openid"]; //access_token 放入Session  
            return msg["access_token"];
        }


        /// <summary>  
        /// 显示错误信息  
        /// </summary>  
        /// <param name="code">错误编号</param>  
        /// <param name="description">错误描述</param>  
        private void ShowError(string code, string description = null)
        {
            if (description == null)
            {
                switch (code)
                {
                    case "20001":
                        description = "<h2>配置文件损坏或无法读取，请检查web.config</h2>";
                        break;
                    case "30001":
                        description = "<h2>The state does not match. You may be a victim of CSRF.</h2>";
                        break;
                    case "50001":
                        description = "<h2>接口未授权</h2>";
                        break;
                    default:
                        description = "<h2>系统未知错误，请联系我们</h2>";
                        break;
                }
                Response.Write(description);
                Response.End();
            }
            else
            {
                Response.Write("<h3>error:<h3>" + code + "<h3>msg:<h3>" + description);
                Response.End();
            }
        }
    }
}