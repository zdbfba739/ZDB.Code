using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZDB.Images.VerificationCode
{
    public class VerificationCode
    {
        /// <summary>
        /// 生成指定字符串的图片
        /// </summary>
        /// <param name="yzm">验证码</param>
        /// <returns>生成的位图</returns>
        public static Bitmap ImageValid(string yzm)
        {
            Bitmap bmp = new Bitmap(120, 35);  //画布大小
            using (Graphics g = Graphics.FromImage(bmp))
            using (Font font = new Font(FontFamily.GenericSerif, 18))
            {
                g.Clear(Color.Yellow);  //背景颜色
                g.DrawString(yzm, font, Brushes.Red, new PointF(0, 10));
                //画图片的背景噪音线
                Random random = new Random();
                int i;
                for (i = 0; i < 25; i++)
                {
                    int x1 = random.Next(bmp.Width);
                    int x2 = random.Next(bmp.Width);
                    int y1 = random.Next(bmp.Height);
                    int y2 = random.Next(bmp.Height);
                    g.DrawLine(new Pen(Color.Blue), x1, y1, x2, y2);
                }
            }
            return bmp;
        }
        /// <summary>
        /// 生成四个随机的汉字字符串
        /// </summary>
        /// <returns></returns>
        public static string ResetValidCode()
        {
            string cyhz = "人口手大小多少上中下男女天地会反清复明黄中华小宝双儿命名空间语现在明天来多个的我山东河北南固安北京南昌东海西安是沙河高教园学"
                + "木禾上下土个八入大天人火文六七儿九无口日中了子门月不开四五目耳头米见白田电也长山出飞马鸟云公车牛羊小少巾牙尺毛又心手水广升足"
                + "走方半巴业本平书自已东西回片皮生里果几用鱼今正雨两瓜衣来年左右万百丁齐冬说友话春朋高你绿们花红草爷亲节的岁行古处声知多忙洗真认父扫"
                + "母爸写全完关家看笑着兴画会妈合奶放午收女气太早去亮和李语秀千香听远唱定连向以更后意主总先起干明赶净同专工才级队蚂蚁前房空网诗黄林闭"
                + "童立是我朵叶美机她过他时送让吗往吧得虫很河借姐呢呀哪谁凉怕量跟最园脸因阳为光可法石找办许别那到都吓叫再做象点像照沙海桥军竹苗井面乡"
                + "忘想念王这从进边道贝男原爱虾跑吹乐地老快师短淡对热冷情拉活把种给吃练学习非苦常问伴间共伙汽分要没孩位选北湖南秋江只帮星请雪就球跳玩"
                + "桃树刚兰座各带坐急名发成动晚新有么在变什条";
            String yzm = "";
            Random rand = new Random();
            for (int i = 0; i < 4; i++)  //每次循环获取一个汉字
            {
                int index = rand.Next(0, cyhz.Length);
                yzm += cyhz[index];
            }
            //context.Session[VALIDCODE] = yzm;    //这里可以用于将获取的字符串存入session中
            return yzm;
        }
    }
}
