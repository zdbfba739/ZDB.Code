using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using O2S.Components.PDFRender4NET;
using ZDB.DBRepository.DbFactory;
using ZDB.DBRepository.Entity;
using ZDB.DBRepository.SQLite;
using ZDB.GenerateUniqueID;
using ZDB.Images.QRCode;

namespace ZDB.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //var uniqueID = MadeUniqueID.GenerateUniqueID();
            //Console.WriteLine(uniqueID);

            #region MyRegion

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

            
            using (var pdf = PDFFile.Open(@"C:\Users\admin\Desktop\1\11.pdf"))
            {
                for (var i = 1; i <= pdf.PageCount; i++)
                {
                    
                    using (var pageImage = pdf.GetPageImage(i - 1, 56 * 3))
                    {
                        //图片的路径及名称
                        var ImgPath = @"C:\Users\admin\Desktop\1\" + DateTime.Now.ToString("yyMMddHHmmss") + ".jpg";

                        //覆盖保存图片
                        pageImage.Save(ImgPath, ImageFormat.Jpeg);
                    }
                }
            }
            Console.Read();
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
