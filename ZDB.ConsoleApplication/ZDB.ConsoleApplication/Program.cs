using System;
using System.IO;
using System.Net;
using ZDB.GenerateUniqueID;
using ZDB.Images.VerificationCode;

namespace ZDB.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 唯一标识
            //var uniqueID = MadeUniqueID.GenerateUniqueID();
            //Console.WriteLine(uniqueID); 
            #endregion

            #region 时间间隔及日志记录

            //try
            //{
            //    var watch = new Stopwatch();
            //    watch.Start();
            //    var uList = new List<UserInfoEntity>();
            //    for (int i = 1; i <= 1000; i++)
            //    {
            //        uList.Add(new UserInfoEntity
            //        {
            //            Name = "Name" + i
            //        });

            //    }
            //    watch.Stop();
            //    //File.AppendAllLines("D:\\log.txt", new List<string>() { $"加载时间：{watch.ElapsedMilliseconds}毫秒" });
            //    Console.WriteLine($"加载时间：{watch.ElapsedMilliseconds}毫秒");
            //    watch.Restart();
            //    // DbService.BeginTransaction();
            //    DbService.Insert(uList);
            //    // DbService.CommitTransaction();
            //    watch.Stop();
            //    Console.WriteLine($"提交时间：{watch.ElapsedMilliseconds}毫秒");
            //}
            //catch (Exception e)
            //{
            //    DbService.RollbackTransaction(e);
            //    throw;
            //}

            #endregion

            #region 参数化查询
            //using (var helper=new SQLiteHelper("170826000001"))
            //{
            //    var dd = helper.Query("select *from PKG_SKU_LIST",new SQLiteParameter {});
            //}
            //try
            //{
            //    Bitmap image = QRCode.GeneratorQrImage("zhang", 300, 300);
            //    image.Save(@"C:\Users\admin\Desktop\新建文件夹\ddd.png");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //} 
            #endregion

            #region 判断取数
            //var source=new List<int>
            //{
            //    1,2,3,4,5,6,7,8,9
            //};

            //var dd = source.Where(x =>
            //{
            //    var idd = false;
            //    if (x == 1||x==7)
            //    {
            //        idd = true;
            //    }
            //    return idd;
            //}).FirstOrDefault(); 
            #endregion

            #region 引用类型及组合方法
            //var dd = 11 / 12;

            //var ddd = new List<List<string>>
            //{
            //    new List<string>
            //    {
            //        "a1",
            //        "a2"
            //    },
            //    new List<string>
            //    {
            //        "b1",
            //        "b2",
            //        "b3"
            //    },
            //    new List<string>
            //    {
            //        "c1",
            //        "c2",
            //        "c3",
            //        "c4"
            //    }
            //};

            //var dd = new List<List<List<string>>>
            //{
            //    ddd,
            //    ddd
            //};

            //var c1 = new string[] { "帽子1", "帽子2", "帽子3" };
            //var c2 = new string[] { "上衣1", "上衣2", "上衣3" };
            //var c3 = new string[] { "裤子a", "裤子b" };
            //var c4 = new string[] { "房子1", "房子2", "房子3", "房子4" };
            //CartesianProduct(new int[] { c1.Length, c2.Length, c3.Length,c4.Length }, (result, len) =>
            //{
            //    Console.WriteLine("{0},{1},{2},{3}", c1[result[0]], c2[result[1]], c3[result[2]], c4[result[3]]);
            //    return true;
            //});
            //dd[0][0].Add("bb"); 
            #endregion

            #region PDF转图片
            //using (var pdf = PDFFile.Open(@"C:\Users\admin\Desktop\1\11.pdf"))
            //{
            //    for (var i = 1; i <= pdf.PageCount; i++)
            //    {

            //        using (var pageImage = pdf.GetPageImage(i - 1, 56 * 3))
            //        {
            //            //图片的路径及名称
            //            var ImgPath = @"C:\Users\admin\Desktop\1\" + DateTime.Now.ToString("yyMMddHHmmss") + ".jpg";

            //            //覆盖保存图片
            //            pageImage.Save(ImgPath, ImageFormat.Jpeg);
            //        }
            //    }
            //} 
            #endregion

            #region 线程传参及开始
            //int i = 5;
            //Thread thread=new Thread((obj) =>
            //{
            //    Console.WriteLine("i="+ obj);
            //});
            //thread.Start(i);
            //i = 6; 

            //new Thread(() => { MadePic(); }).Start();
            #endregion

            #region Get|Post请求处理
            //Console.WriteLine("Starting...");

            //Console.WriteLine("Making API call...");
            //string url = "http://192.168.1.244:8045/api/v1.0/Tools/GetPluginList";
            //HttpWebRequest request;

            //request = (HttpWebRequest)WebRequest.Create(url);
            //request.Headers.Add("Authorization", "Bearer eyJDbGFpbXMiOlt7IlR5cGUiOiJJZCIsIlZhbHVlIjoiMTEyMjEzIn0seyJUeXBlIjoiY29tcElkIiwiVmFsdWUiOiIxMSJ9XSwiRXhwaXJlc1V0YyI6IjIwMTgtMDktMTlUMDc6MzM6NTErMDA6MDAifQ==");
            //GetResponse(request);

            //Console.WriteLine("Test 2");
            //request = (HttpWebRequest)WebRequest.Create(url);
            //request.ContentType = "application/json; charset=utf-8";
            //GetResponse(request);

            //Console.WriteLine("Test 3");
            //request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "POST";
            //GetResponse(request);

            //Console.WriteLine("Test 4");
            //request = (HttpWebRequest)WebRequest.Create(url);
            //request.ContentType = "application/json; charset=utf-8";
            //request.Method = "POST";
            //GetResponse(request);

            //Console.WriteLine("Done!"); 
            #endregion

            Console.ReadKey();

            Console.Read();
        }

        public static void GetResponse(HttpWebRequest request)
        {
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var stream = response.GetResponseStream();
                    var reader = new StreamReader(stream);
                    var result = reader.ReadToEnd();
                    Console.WriteLine(result);
                    reader.Close();
                    reader.Dispose();
                    response.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("*** Failed: Error '" + e.Message + "'.");
            }
        }

        public static void MadePic()
        {
            for (int i = 0; i < 7000; i++)
            {
                var dd = VerificationCode.ImageValid(VerificationCode.ResetValidCode());
                dd.Save(@"C:\Users\admin\Desktop\2\" + MadeUniqueID.GenerateUniqueID() + ".jpg");
            }
        }

        public delegate bool SetAlgorithmCallback(int[] result, int length);

        static bool CartesianProduct(int[] sets, int i, int[] result, SetAlgorithmCallback callback)
        {
            for (var j = 0; j < sets[i]; ++j)
            {
                result[i] = j;
                if (i == sets.Length - 1)
                {
                    if (!callback(result, result.Length))
                        return false;
                }
                else
                {
                    if (!CartesianProduct(sets, i + 1, result, callback))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 求集合笛卡尔积
        /// </summary>
        /// <param name="sets">包含集合元素个数的数组</param>
        /// <param name="callback">回调函数</param>
        public static void CartesianProduct(int[] sets, SetAlgorithmCallback callback)
        {
            int[] result = new int[sets.Length];
            CartesianProduct(sets, 0, result, callback);
        }

    }
}
