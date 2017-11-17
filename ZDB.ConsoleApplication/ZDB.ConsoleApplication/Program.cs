#define Dragon
#define Debug
#define Trace
#if (Debug && Trace)
#define DebugAndTrace
#endif
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ZDB.GenerateUniqueID;
using ZDB.Images.VerificationCode;
using System.Web.Script.Serialization;

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

            #region 二维码处理

            //for (int i = 0; i < 100; i++)
            //{
            //    var dd = QRCode.EnCoder("12345");
            //    dd.Save(@"C:\Users\admin\Desktop\3\" + MadeUniqueID.GenerateUniqueID() + ".jpg");
            //}
            //QRCode.ToFile(@"C:\Users\admin\Desktop\3\", @"C:\Users\admin\Desktop\31pack.zip", QRCode.PackingScope.All);
            //Console.WriteLine(QRCode.DeCoder(@"C:\Users\admin\Desktop\3\2017092009124492392214.jpg")); 

            #endregion

            #region 未知json转实体

            //var dd = DbService.GetList<dynamic>("select * from userinfo LIMIT 10").FirstOrDefault();
            ////基础数据
            //Dictionary<string, string> basisValues = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(JsonConvert.SerializeObject(dd)); 

            #endregion

            #region XLS处理

            //var filePath = @"D:\Web\Md.Api.Down\ep\attachment\1000\127\123.xlsx";

            //var xlsDb = CommonXls.ExcelToDataTable(filePath, "Sheet1", true);
            //IWorkbook workbook=null;
            //string fileExt = Path.GetExtension(filePath);

            //using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //{
            //    if (fileExt == ".xls")
            //    {
            //        workbook = new HSSFWorkbook(file);
            //    }
            //    else if (fileExt == ".xlsx")
            //    {
            //        workbook = new XSSFWorkbook(file);
            //    }
            //    ISheet sheet = workbook.GetSheetAt(0);

            //    var firstRow = sheet.GetRow(0);
            //} 

            #endregion

            #region 替换字符

            //var dd = GetReplaceName(@"\/:*?＂|"); 

            #endregion

            #region 处理组合

            //var dd = GetFillSet(new List<List<string>>
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
            //        "d1",
            //        "d2"
            //    },
            //    new List<string>
            //    {
            //        "c1",
            //        "c2",
            //        "c3",
            //        "c4"
            //    }
            //}, 0);

            #endregion

            #region GroupBy分组

            //var dd = new List<dynamic>
            //{
            //    new
            //    {
            //        WorkShopID = 1,
            //        DemandID = 22,
            //        FinishQuantity = 51,
            //        CreateDate = new DateTime(2017, 10, 17, 12, 30, 50),
            //        JobName = "下料1",
            //        ProcessProgress = "工序1"
            //    },
            //    new
            //    {
            //        WorkShopID = 2,
            //        DemandID = 22,
            //        FinishQuantity = 51,
            //        CreateDate = new DateTime(2017, 10, 17, 12, 30, 54),
            //        JobName = "下料2",
            //        ProcessProgress = "工序2"
            //    },
            //    new
            //    {
            //        WorkShopID = 1,
            //        DemandID = 22,
            //        FinishQuantity = 51,
            //        CreateDate = new DateTime(2017, 10, 17, 12, 30, 51),
            //        JobName = "下料3",
            //        ProcessProgress = "工序3"
            //    },
            //    new
            //    {
            //        WorkShopID = 2,
            //        DemandID = 22,
            //        FinishQuantity = 51,
            //        CreateDate = new DateTime(2017, 10, 17, 12, 30, 53),
            //        JobName = "下料4",
            //        ProcessProgress = "工序4"
            //    },
            //    new
            //    {
            //        WorkShopID = 1,
            //        DemandID = 22,
            //        FinishQuantity = 51,
            //        CreateDate = new DateTime(2017, 10, 17, 12, 30, 58),
            //        JobName = "下料5",
            //        ProcessProgress = "工序5"
            //    }
            //};
            //var aa = dd.GroupBy(g => new {g.WorkShopID, g.DemandID}).Select(x => new
            //{
            //    x.Key.DemandID,
            //    x.Key.WorkShopID,
            //    info = x.FirstOrDefault(y => y.CreateDate == x.Max(m => m.CreateDate))
            //}).ToList();
            //var aa1 = dd.GroupBy(g => new {g.WorkShopID, g.DemandID}).Select(x =>
            //{

            //    var info = x.FirstOrDefault(y => y.CreateDate == x.Max(m => m.CreateDate));
            //    return new
            //    {
            //        x.Key.DemandID,
            //        x.Key.WorkShopID,
            //        info.FinishQuantity,
            //        info.CreateDate,
            //        info.JobName,
            //        info.ProcessProgress
            //    };
            //}).ToList();

            #endregion

            #region 条件编译

            //#if Dragon
            //            Console.WriteLine("Dragon is defined");
            //#else
            //            Console.WriteLine("Dragon is not defined");
            //#endif

            //            Print0();
            //            Print1();
            //            Print2();
            //            Print3(); 

            #endregion

            #region Json格式化

            //string json = "[{\"name\":\"zhang3\"},{\"name\":\"zhang4\"}]";

            //var j = new JsonParser().FromJson(json);
            ////j是个 object[]
            //int len = j.Length;
            //var obj1 = j[0];
            //var name = j[1].name; 

            #endregion

            #region ToDictionary

            //var CustomObject = new List<dynamic>
            //{
            //    new
            //    {
            //        Name = "aaa",
            //        Code = 1
            //    },
            //    new
            //    {
            //        Name = "aaa",
            //        Code = 2
            //    },
            //    new
            //    {
            //        Name = "bbb",
            //        Code = 1
            //    }
            //};
            //var dic = CustomObject.GroupBy(o => o.Name)
            //    .ToDictionary(g => g.Key, g => g.ToList()); 

            #endregion

            #region DataTable操作及is as
            //Parallel.For(0, 10, (i) =>
            //{
            //    while (true)
            //    {
            //        var webRequest = (HttpWebRequest)WebRequest.CreateHttp("http://www.cnblogs.com/modestmt/p/7724821.html");
            //        var response = webRequest.GetResponse();
            //        response.Dispose();
            //        Console.WriteLine($"Process: {i}.");
            //        Thread.Sleep(500000);
            //    }
            //});

            //DataTable dt = new DataTable();
            //dt.TableName = "user";
            //dt.Columns.Add("id", typeof(int));
            //dt.Columns.Add("name", typeof(string));
            //for (int i = 1; i < 11; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["id"] = i;
            //    dr["name"] = "name" + i;
            //    dt.Rows.Add(dr);
            //}
            //var aa = dt.AsDataView();
            //var dd = dt.AsEnumerable().Where(x => x.Field<int>("id") > 5).AsDataView();

            //object i = 1;
            //var a = i as int?;
            //var b = i is int;
            //var c = i as string;

            //Console.WriteLine(DateTime.Now.ToString("yyyy年MM月dd日HH时mm分"));
            //Console.WriteLine(DateTime.Now.ToString("yyyy年mm月dd日hh时mm分")); 
            #endregion

            #region 自定义属性
            //获取MethodToRun类的静态方法集合
            //MethodInfo[] methods = typeof(MethodToRun).GetMethods(BindingFlags.Public | BindingFlags.Static);
            //foreach (var method in methods)
            //{
            //    MethodInfo info = method;
            //    //获取每个方法上的Attributes集合
            //    var attributes = info.GetCustomAttributes(typeof(Attribute), false);

            //    foreach (var attri in attributes)
            //    {
            //        //如果自定义的标签是指定的标签则符合条件
            //        if (attri is ExcuteAttribute)
            //        {
            //            ExcuteAttribute exe = attri as ExcuteAttribute;
            //            //执行Flag为1的方法
            //            if (exe.Flag == 1)
            //            {
            //                //info.Invoke(null, null);
            //            }
            //        }
            //        if (attri is CustomFilterAttribute)
            //        {
            //            CustomFilterAttribute cust = attri as CustomFilterAttribute;
            //            cust.OnBeforeAction();
            //            info.Invoke(null, null);
            //            cust.OnAfterAction();
            //        }
            //    }
            //} 
            #endregion

            //var cancelTokenSource = new CancellationTokenSource(10000);

            //Task.Factory.StartNew(() =>
            //{
            //    while (!cancelTokenSource.IsCancellationRequested)
            //    {
            //        Console.WriteLine(DateTime.Now);
            //        Thread.Sleep(1000);
            //    }
            //}, cancelTokenSource.Token);

            //Console.WriteLine("Press any key to cancel");
            ////Console.ReadLine();
            //cancelTokenSource.CancelAfter(20000);
            //Console.WriteLine("Done");

            Task<int> task = Task.Run(() => Enumerable.Range(1, 5000000).Count(n => (n % 3) == 0));

            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine("整除3的个数有：" + result);
                Console.WriteLine("Task执行中...");
                Console.ReadLine();
            });


            Console.ReadLine();

            Console.Read();
        }


        #region 条件编译
        [Conditional("Debug")]
        static void Print0()
        {
            Console.WriteLine("DEBUG is defined");
        }

        [Conditional("Debug1")]
        static void Print1()
        {
            Console.WriteLine("Debug is defined1");
        }

        //定义了Debug或者Trace后才会执行此方法
        //或者的关系
        [Conditional("Debug"), Conditional("Trace")]
        static void Print2()
        {
            Console.WriteLine("Debug or Trace is defined");
        }

        //只有定义了Debug和Trace后才会执行此方法
        //并且的关系
        [Conditional("DebugAndTrace")]
        static void Print3()
        {
            Console.WriteLine("Debug and Trace is defined");
        }
        #endregion

        #region MyRegion

        public static List<List<string>> GetFillSet(List<List<string>> p_List, int p_Index)
        {
            List<List<string>> m_SubList = new List<List<string>>();

            if (p_List.Count == p_Index)
            {
                return m_SubList;
            }

            m_SubList = GetFillSet(p_List, p_Index + 1);

            List<List<string>> m_Result = new List<List<string>>();

            foreach (var t_ValueItem in p_List[p_Index])
            {
                if (m_SubList.Count == 0)
                {
                    m_Result.Add(new List<string>
                    {
                        t_ValueItem
                    });
                }
                foreach (var t_SubItem in m_SubList)
                {
                    var newItem = new List<string>
                    {
                        t_ValueItem
                    };
                    t_SubItem.ForEach(x =>
                    {
                        newItem.Add(x);
                    });
                    m_Result.Add(newItem);
                }

            }
            return m_Result;
        }

        public static string GetReplaceName(string ItemName)
        {
            if (string.IsNullOrWhiteSpace(ItemName))
            {
                return ItemName;
            }
            return ItemName.Replace("\\", "＼")
                .Replace("/", "／")
                .Replace(":", "：")
                .Replace("*", "＊")
                .Replace("?", "？")
                .Replace("\"", "＂")
                .Replace("|", "｜");
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

        #endregion

        /// <summary>
        /// json转换
        /// </summary>
        public class JsonParser
        {

            /// <summary>
            /// 从json字符串到对象。
            /// </summary>
            /// <param name="jsonStr"></param>
            /// <returns></returns>
            public dynamic FromJson(string jsonStr)
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });

                dynamic glossaryEntry = jss.Deserialize(jsonStr, typeof(object)) as dynamic;
                return glossaryEntry;
            }
        }

        public class DynamicJsonConverter : JavaScriptConverter
        {
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");

                if (type == typeof(object))
                {
                    return new DynamicJsonObject(dictionary);
                }

                return null;
            }

            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<Type> SupportedTypes
            {
                get { return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(object) })); }
            }
        }

        public class DynamicJsonObject : DynamicObject
        {
            private IDictionary<string, object> Dictionary { get; set; }

            public DynamicJsonObject(IDictionary<string, object> dictionary)
            {
                this.Dictionary = dictionary;
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                result = this.Dictionary[binder.Name];

                if (result is IDictionary<string, object>)
                {
                    result = new DynamicJsonObject(result as IDictionary<string, object>);
                }
                else if (result is ArrayList && (result as ArrayList) is IDictionary<string, object>)
                {
                    result = new List<DynamicJsonObject>((result as ArrayList).ToArray().Select(x => new DynamicJsonObject(x as IDictionary<string, object>)));
                }
                else if (result is ArrayList)
                {
                    result = new List<object>((result as ArrayList).ToArray());
                }

                return this.Dictionary.ContainsKey(binder.Name);
            }
        }
    }
}
