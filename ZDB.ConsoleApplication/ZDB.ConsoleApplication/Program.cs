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
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using ZDB.GenerateUniqueID;
using ZDB.Images.VerificationCode;
using System.Web.Script.Serialization;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using ZDB.DBRepository.DbFactory;
using ZDB.DBRepository.Entity;
using ZDB.Images.ZoomPic;
using ZDB.DesignPatterns;
using PictureType = NPOI.SS.UserModel.PictureType;
using Microsoft.VisualBasic;

namespace ZDB.ConsoleApplication
{
    class Program
    {

        //private static Queue m_inputQueue = new Queue();
        private static System.Timers.Timer timer = null;

        /// <summary>
        /// 信号量
        /// </summary>
        static Semaphore sema = new Semaphore(5, 5);
        const int cycleNum = 20;

        static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();

        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);
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

            #region 线程
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

            //Task<int> task = Task.Run(() => Enumerable.Range(1, 5000000).Count(n => (n % 3) == 0));

            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() =>
            //{
            //    int result = awaiter.GetResult();
            //    Console.WriteLine("整除3的个数有：" + result);
            //    Console.WriteLine("Task执行中...");
            //    Console.ReadLine();
            //});
            //var fileInfo = new FileInfo(@"C:\Users\admin\Desktop\123.jpg");
            //fileInfo.DirectoryName

            //ZoomPic.ZoomPicture(@"C:\Users\admin\Desktop\123.jpg",100,200); 
            #endregion

            #region NPOI WORD
            //XWPFDocument doc = new XWPFDocument();
            //XWPFParagraph p0 = doc.CreateParagraph();
            //p0.Alignment = ParagraphAlignment.LEFT;
            //XWPFRun r0 = p0.CreateRun();
            //r0.FontFamily = "宋体";
            //r0.FontSize = 18;
            //r0.IsBold = true;
            //r0.SetText("未登录过学生的账号密码");

            //XWPFParagraph p1 = doc.CreateParagraph();
            //p1.Alignment = ParagraphAlignment.LEFT;
            //XWPFRun r1 = p1.CreateRun();
            //r1.FontFamily = "宋体";
            //r1.FontSize = 10;
            //r1.IsBold = true;
            //r1.SetText("(备注：已登录过的学生密码不显示)");

            //XWPFParagraph p2 = doc.CreateParagraph();
            //p2.Alignment = ParagraphAlignment.LEFT;
            //XWPFRun r2 = p2.CreateRun();
            //r2.FontFamily = "宋体";
            //r2.FontSize = 10;
            //r2.IsBold = true;
            //r2.SetText("学校：XX一中");

            //XWPFParagraph p3 = doc.CreateParagraph();
            //p3.Alignment = ParagraphAlignment.LEFT;
            //XWPFRun r3 = p3.CreateRun();
            //r3.FontFamily = "宋体";
            //r3.FontSize = 10;
            //r3.IsBold = true;
            //r3.SetText("班级：(7)");

            //XWPFParagraph p4 = doc.CreateParagraph();
            //p4.Alignment = ParagraphAlignment.LEFT;
            //XWPFRun r4 = p4.CreateRun();
            //r4.FontFamily = "宋体";
            //r4.FontSize = 10;
            //r4.IsBold = true;
            //r4.SetText("班主任：ddd");


            //XWPFParagraph p5 = doc.CreateParagraph();
            //p5.Alignment = ParagraphAlignment.LEFT;
            //XWPFRun r5 = p5.CreateRun();
            //r5.FontFamily = "宋体";
            //r5.FontSize = 10;
            //r5.IsBold = true;
            //r5.SetText("可以在此处添加备注：");
            //XWPFTable table = doc.CreateTable(4, 4);
            //table.SetColumnWidth(0,5*256);
            //table.SetColumnWidth(0, 10 * 256);
            //table.SetColumnWidth(0, 15 * 256);
            //table.SetColumnWidth(0, 20 * 256);
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    XWPFParagraph pIO = table.GetRow(i).GetCell(0).AddParagraph();
            //    XWPFRun rIO = pIO.CreateRun();
            //    rIO.FontFamily = "微软雅黑";
            //    rIO.FontSize = 12;
            //    rIO.IsBold = true;
            //    rIO.SetText(i.ToString());


            //    XWPFParagraph pINo = table.GetRow(i).GetCell(1).AddParagraph();
            //    XWPFRun rINo = pINo.CreateRun();
            //    rINo.FontFamily = "微软雅黑";
            //    rINo.FontSize = 12;
            //    rINo.IsBold = true;
            //    rINo.SetText("name" + i);


            //    XWPFParagraph pIMm = table.GetRow(i).GetCell(2).AddParagraph();
            //    XWPFRun rIMm = pIMm.CreateRun();
            //    rIMm.FontFamily = "微软雅黑";
            //    rIMm.FontSize = 12;
            //    rIMm.IsBold = true;
            //    rIMm.SetText("PassWord" + i);


            //    XWPFParagraph pIName = table.GetRow(i).GetCell(3).AddParagraph();
            //    XWPFRun rIName = pIName.CreateRun();
            //    rIName.FontFamily = "微软雅黑";
            //    rIName.FontSize = 12;
            //    rIName.IsBold = true;
            //    rIName.SetText("StudentName" + i);
            //}
            //var id = Guid.NewGuid().ToString("N");
            //var file = File.Create(@"C:\Users\admin\Desktop\xf\" + id + ".docx");
            //doc.Write(file);

            //var paramList = new Dictionary<string, string>();
            //paramList.Add("aa","");
            //if (paramList.ContainsKey("aa"))
            //{
            //    paramList["aa"] = "1";
            //}

            // new NPOIWord().CreateWord(); 
            #endregion

            #region 线程锁
            //Thread[] threads = new Thread[10];
            //Account acc = new Account(1000);
            //for (int i = 0; i < 10; i++)
            //{
            //    Thread t = new Thread(new ThreadStart(acc.DoTransactions));
            //    threads[i] = t;
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    threads[i].Start();
            //}

            ////block main thread until all other threads have ran to completion.
            //foreach (var t in threads)
            //    t.Join(); 
            #endregion

            #region 多线程
            //var spath = "E:";
            //for (int i = 1; i <= 30; i++)
            //{
            //    spath += "\\" + i;
            //}
            //var dir = new DirectoryInfo(spath);
            //if (!dir.Exists)
            //{
            //    dir.Create();
            //}
            // string[] array = new string[] { "2", "3", "10" };
            // var dd = array.ToArray().ToList();

            //var cc= dd.Select((x, y) => x + y);
            //MakeRequest();

            //timer = new System.Timers.Timer(1 * 6 * 1000);
            //timer.Elapsed += Timer_Elapsed;
            //timer.Start();

            //int i, j, k;
            //for (i = 1; i < 5; i++)
            //    for (j = 1; j < 5; j++)
            //        for (k = 1; k < 5; k++)
            //        {
            //            if (i != k && i != j && j != k)
            //                Console.WriteLine(i + "," + j + "," + k);
            //        }

            //Program sample = new Program();

            //for (int i = 0; i < 30; i++)
            //    sample.AddElement(i);
            //sample.PrintAllElements();
            //sample.DeleteElement(0);
            //sample.DeleteElement(10);
            //sample.DeleteElement(20);
            //sample.PrintAllElements();


            //for (int i = 0; i < cycleNum; i++)
            //{
            //    Thread td = new Thread(new ParameterizedThreadStart(testFun));
            //    td.Name = string.Format("编号{0}", i.ToString());
            //    td.Start(td.Name);
            //}
            //Console.ReadKey(); 
            #endregion

            #region 操作同一文件防报错
            //var dd = SingletonPattern.GetInstance();

            ////dd.GetUUID();

            //for (int i = 0; i < 1000; i++)
            //{
            //    Thread thread = new Thread((obj) =>
            //      {
            //          for (int j = 0; j < 100; j++)
            //          {
            //              LogWriteLock.EnterWriteLock();
            //              File.AppendAllText(@"C:\Users\admin\Desktop\新建文件夹\1.txt", dd.GetUUID()+"\r\n");
            //              LogWriteLock.ExitWriteLock();
            //              //Console.WriteLine(obj..ManagedThreadId + "=" + dd.GetUUID());
            //          }
            //      });
            //    thread.Start(i);
            //} 
            #endregion

            #region Model Json Xml互转
            //var dd = new List<Goods>
            //{
            //    new Goods
            //    {
            //        ProdName = "123",
            //        SkuName = "s123",
            //        Num = 2,
            //        ZhongLiang = 12.1
            //    },
            //    new Goods
            //    {
            //        ProdName = "123",
            //        SkuName = "s1234",
            //        Num = 3,
            //        ZhongLiang = 12.3
            //    },
            //    new Goods
            //    {
            //        ProdName = "123",
            //        SkuName = "s123",
            //        Num = 3,
            //        ZhongLiang = 12.4
            //    }
            //};

            //var ddd = new Goods
            //{
            //    ProdName = "123",
            //    SkuName = "s123",
            //    Num = 2,
            //    ZhongLiang = 12.1
            //};

            //对象转json
            //var json = JsonConvert.SerializeObject(ddd);

            //json转xml
            //var xml = JsonConvert.DeserializeXmlNode(json);
            //var xml = JsonConvert.DeserializeXNode(json);

            //xml转json
            //json = JsonConvert.SerializeXmlNode(xml);

            //json转对象
            //ddd = JsonConvert.DeserializeObject<Goods>(json);

            //var ddd = dd.GroupBy(x => new { x.ProdName, x.SkuName }).Select(y =>
            //    {
            //        var num = y.Sum(z => z.Num);
            //        var zl = y.Sum(z => z.ZhongLiang) / num;
            //        return new
            //        {
            //            y.Key.ProdName,
            //            y.Key.SkuName,
            //            Num = num,
            //            ZhongLiang = zl

            //        };
            //    }); 
            #endregion

            #region pdf操作
            ////实例化
            //iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
            ////设置文档大小
            //iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(600, 450);
            //document.SetPageSize(rect);

            //PdfWriter.GetInstance(document, new System.IO.FileStream("F:\\test1.pdf", System.IO.FileMode.Create));

            //PdfPTable table = new PdfPTable(4);

            //PdfPCell header = new PdfPCell(new Phrase("用户信息"));
            //header.Colspan = 3;
            //header.HorizontalAlignment = 1;
            //table.AddCell(header);

            //table.AddCell("姓名");
            //table.AddCell("年龄");
            //table.AddCell("性别");
            //table.AddCell("生日");

            //table.AddCell("李雷");
            //table.AddCell("23");
            //table.AddCell("男");
            //table.AddCell("1980-01-01");

            //table.AddCell("韩梅梅");
            //table.AddCell("22");
            //table.AddCell("女");
            //table.AddCell("1982-04-03");

            //table.AddCell("隔壁老王");
            //table.AddCell("25");
            //table.AddCell("男");
            //table.AddCell("1977-03-12");

            //document.Open();
            //document.Add(table);
            //document.Close();


            //PdfReader reader = new PdfReader("F:\\navicat.pdf");

            //var tempBookmarks = SimpleBookmark.GetBookmark(reader);

            //CreateWJJ(tempBookmarks); 
            #endregion

            #region 生产xls表格

            //IWorkbook workbook = new HSSFWorkbook();

            ////新建工作表
            //var sheet = workbook.CreateSheet("sheet1");

            //#region 第一行
            ////设置第一行单元格
            //sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 4));
            //sheet.AddMergedRegion(new CellRangeAddress(0, 0, 5, 14));
            //sheet.AddMergedRegion(new CellRangeAddress(0, 0, 15, 19));

            //var bytes = System.IO.File.ReadAllBytes(@"E:\my3Dparts\MyCode\Code\ZDB.Code\ZDB.ConsoleApplication\ZDB.ConsoleApplication\bin\Debug\图片1.png");
            //var pictureIdx = workbook.AddPicture(bytes, PictureType.JPEG);
            //var patriarch = sheet.CreateDrawingPatriarch();

            ////添加图片
            //var anchor = new HSSFClientAnchor(20, 5, 3, 5, 0, 0, 5, 1);
            //var pict = patriarch.CreatePicture(anchor, pictureIdx);
            //pict.Resize(0.99, 0.99);
            ////创建第一行
            //var row = sheet.CreateRow(0);
            //row.CreateCell(5).SetCellValue("货物交接清单\nCARGO RECEIPT FOR AIR COOLED CONDENSER");
            //row.CreateCell(15).SetCellValue("车次编号： NO.4");
            //row.Height = 50 * 20;
            //#endregion

            //#region 第二行
            ////设置第二行单元格
            //sheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, 3));
            //sheet.AddMergedRegion(new CellRangeAddress(1, 1, 4, 8));
            //sheet.AddMergedRegion(new CellRangeAddress(1, 1, 9, 11));
            //sheet.AddMergedRegion(new CellRangeAddress(1, 1, 12, 14));
            //sheet.AddMergedRegion(new CellRangeAddress(1, 1, 15, 16));
            //sheet.AddMergedRegion(new CellRangeAddress(1, 1, 17, 19));

            ////创建第二行
            //var row1 = sheet.CreateRow(1);
            //row1.CreateCell(0).SetCellValue("项目名称\nProject Name");
            //row1.CreateCell(4).SetCellValue("120万吨/年连续重整装置重整循环氢机组");
            //row1.CreateCell(9).SetCellValue("项目号\nProjectNo.");
            //row1.CreateCell(12).SetCellValue("A0021");
            //row1.CreateCell(15).SetCellValue("订单号\nPO No: ");
            //row1.Height = 50 * 20;
            //#endregion

            //#region 第三行
            ////设置第三行单元格
            //sheet.AddMergedRegion(new CellRangeAddress(2, 2, 0, 9));
            //sheet.AddMergedRegion(new CellRangeAddress(2, 2, 10, 14));
            //sheet.AddMergedRegion(new CellRangeAddress(2, 2, 15, 19));

            ////创建第三行
            //var row2 = sheet.CreateRow(2);
            //row2.CreateCell(0).SetCellValue("Shipping Mark：");
            //row2.CreateCell(10).SetCellValue("提货凭证\nTaking Evidence");
            //row2.Height = 50 * 20;
            //#endregion

            //#region 第四行
            ////设置第四行单元格
            //sheet.AddMergedRegion(new CellRangeAddress(3, 3, 0, 2));
            //sheet.AddMergedRegion(new CellRangeAddress(3, 3, 3, 9));
            //sheet.AddMergedRegion(new CellRangeAddress(3, 3, 10, 14));
            //sheet.AddMergedRegion(new CellRangeAddress(3, 3, 15, 19));

            ////创建第四行
            //var row3 = sheet.CreateRow(3);
            //row3.CreateCell(0).SetCellValue("发货人Consigner");
            //row3.CreateCell(3).SetCellValue("杭州汽轮辅机有限公司\n叶群 13067960835");
            //row3.Height = 50 * 20;
            //#endregion

            //#region 第五行
            ////设置第五行单元格
            //sheet.AddMergedRegion(new CellRangeAddress(4, 4, 0, 2));
            //sheet.AddMergedRegion(new CellRangeAddress(4, 4, 3, 9));
            //sheet.AddMergedRegion(new CellRangeAddress(4, 4, 10, 14));
            //sheet.AddMergedRegion(new CellRangeAddress(4, 4, 15, 19));

            ////创建第五行
            //var row4 = sheet.CreateRow(4);
            //row4.CreateCell(0).SetCellValue("收货人Receiver");
            //row4.CreateCell(3).SetCellValue("王修华（供应部）13791875706\n 0536 - 3556556");
            //row4.CreateCell(10).SetCellValue("运输方式\nTransport.Mode");
            //row4.CreateCell(15).SetCellValue("汽运");
            //row4.Height = 50 * 20;
            //#endregion

            //#region 第六行
            ////设置第六行单元格
            //sheet.AddMergedRegion(new CellRangeAddress(5, 5, 0, 2));
            //sheet.AddMergedRegion(new CellRangeAddress(5, 5, 3, 9));
            //sheet.AddMergedRegion(new CellRangeAddress(5, 5, 10, 14));
            //sheet.AddMergedRegion(new CellRangeAddress(5, 5, 15, 19));

            ////创建第六行
            //var row5 = sheet.CreateRow(5);
            //row5.CreateCell(0).SetCellValue("运输单位\nTransport.Unit");
            //row5.CreateCell(3).SetCellValue("杭汽轮运输分公司 ");
            //row5.CreateCell(10).SetCellValue("发货日期\nDelivery Date");
            //row5.CreateCell(15).SetCellValue("2016-8-23");
            //row5.Height = 50 * 20;
            //#endregion

            //#region 第七行
            ////设置第七行单元格
            //sheet.AddMergedRegion(new CellRangeAddress(6, 6, 0, 2));
            //sheet.AddMergedRegion(new CellRangeAddress(6, 6, 3, 9));
            //sheet.AddMergedRegion(new CellRangeAddress(6, 6, 10, 14));
            //sheet.AddMergedRegion(new CellRangeAddress(6, 6, 15, 19));

            ////创建第七行
            //var row6 = sheet.CreateRow(6);
            //row6.CreateCell(0).SetCellValue("到货站（点）\nArrival Station(Point)");
            //row6.CreateCell(3).SetCellValue("山东省青州市口埠徐集，中化弘润石油化工有限公司");
            //row6.CreateCell(10).SetCellValue("预计到货日期\nforecast delivery date");
            //row6.CreateCell(15).SetCellValue("2016-8-25");
            //row6.Height = 50 * 20;
            //#endregion

            //#region 第八行
            ////设置第八行单元格
            //sheet.AddMergedRegion(new CellRangeAddress(7, 7, 0, 19));

            ////创建第八行
            //var row7 = sheet.CreateRow(7);
            //row7.CreateCell(0).SetCellValue("货物说明Goods Description(Details are as per attached Summary Packing List详见内附的装箱清单)");
            //row7.Height = 25 * 20;
            //#endregion

            //#region 第九行
            ////设置第九行单元格
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 0, 0));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 1, 1));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 2, 5));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 6, 6));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 7, 7));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 8, 10));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 11, 12));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 13, 13));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 14, 15));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 16, 17));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 18, 18));
            //sheet.AddMergedRegion(new CellRangeAddress(8, 8, 19, 19));

            ////创建第九行
            //var row8 = sheet.CreateRow(8);
            //row8.CreateCell(0).SetCellValue("包\n装\n编\n号");
            //row8.CreateCell(1).SetCellValue("箱件号");
            //row8.CreateCell(2).SetCellValue("位号");
            //row8.CreateCell(6).SetCellValue("货物\n名称");
            //row8.CreateCell(7).SetCellValue("包装\n形式");
            //row8.CreateCell(8).SetCellValue("包装尺寸cm\n（长×宽×高）");
            //row8.CreateCell(11).SetCellValue("数\n量\n(包)");
            //row8.CreateCell(13).SetCellValue("净重\n(kg/包)");
            //row8.CreateCell(14).SetCellValue("总重(净)\n(kg)");
            //row8.CreateCell(16).SetCellValue("毛重\n(kg/包)");
            //row8.CreateCell(18).SetCellValue("总重\n(毛)\n(kg)");
            //row8.CreateCell(19).SetCellValue("备注\nRemarks");
            //row8.Height = 60 * 20;

            ////row8.Height = 25 * 20;
            ////row8.GetCell(0).CellStyle = style0;
            ////row8.GetCell(1).CellStyle = style0;
            ////row8.GetCell(2).CellStyle = style0;
            ////row8.GetCell(6).CellStyle = style0;
            ////row8.GetCell(7).CellStyle = style0;
            ////row8.GetCell(8).CellStyle = style0;
            ////row8.GetCell(11).CellStyle = style0;
            ////row8.GetCell(13).CellStyle = style0;
            ////row8.GetCell(14).CellStyle = style0;
            ////row8.GetCell(16).CellStyle = style0;
            ////row8.GetCell(18).CellStyle = style0;
            ////row8.GetCell(19).CellStyle = style0;
            ////row8.RowStyle= style0;


            //#endregion

            //#region 动态数据行
            //var dbCount = 4;
            ////循环加数据
            //for (var i = 1; i <= dbCount; i++)
            //{
            //    //设置单元格
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 0, 0));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 1, 1));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 2, 5));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 6, 6));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 7, 7));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 8, 10));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 11, 12));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 13, 13));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 14, 15));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 16, 17));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 18, 18));
            //    sheet.AddMergedRegion(new CellRangeAddress(8 + i, 8 + i, 19, 19));

            //    //创建行
            //    var rowNew = sheet.CreateRow(8 + i);
            //    rowNew.CreateCell(0).SetCellValue(i);
            //    rowNew.CreateCell(1).SetCellValue("A0021-1");
            //    rowNew.CreateCell(2).SetCellValue("C-3201-ST");
            //    rowNew.CreateCell(6).SetCellValue("管束");
            //    rowNew.CreateCell(7).SetCellValue("裸装");
            //    rowNew.CreateCell(8).SetCellValue("778*295*333");
            //    rowNew.CreateCell(11).SetCellValue("1");
            //    rowNew.CreateCell(13).SetCellValue("");
            //    rowNew.CreateCell(14).SetCellValue("");
            //    rowNew.CreateCell(16).SetCellValue("");
            //    rowNew.CreateCell(18).SetCellValue("18500");
            //    rowNew.CreateCell(19).SetCellValue("见附件详单");
            //}
            //#endregion

            //#region 合计行
            ////设置单元格
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 0, 0));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 1, 1));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 2, 5));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 6, 6));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 7, 7));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 8, 10));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 11, 12));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 13, 13));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 14, 15));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 16, 17));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 18, 18));
            //sheet.AddMergedRegion(new CellRangeAddress(9 + dbCount, 9 + dbCount, 19, 19));

            ////创建行
            //var rowTotal = sheet.CreateRow(9 + dbCount);
            //rowTotal.CreateCell(0).SetCellValue("Total\n总计");
            //rowTotal.CreateCell(1).SetCellValue("");
            //rowTotal.CreateCell(2).SetCellValue("");
            //rowTotal.CreateCell(6).SetCellValue("");
            //rowTotal.CreateCell(7).SetCellValue("");
            //rowTotal.CreateCell(8).SetCellValue("");
            //rowTotal.CreateCell(11).SetCellValue("");
            //rowTotal.CreateCell(13).SetCellValue("");
            //rowTotal.CreateCell(14).SetCellValue("");
            //rowTotal.CreateCell(16).SetCellValue("");
            //rowTotal.CreateCell(18).SetCellValue("");
            //rowTotal.CreateCell(19).SetCellValue("");
            //#endregion

            //#region 最后行
            ////设置单元格
            //sheet.AddMergedRegion(new CellRangeAddress(10 + dbCount, 10 + dbCount, 0, 6));
            //sheet.AddMergedRegion(new CellRangeAddress(10 + dbCount, 10 + dbCount, 7, 19));

            ////创建行
            //var rowLas = sheet.CreateRow(10 + dbCount);
            //rowLas.CreateCell(0).SetCellValue("搬运、储存产品的防护要求\nProtection requirements for\nCarrying and storage of goods");
            //rowLas.CreateCell(7).SetCellValue("√小心轻放；       √   防潮；             √    防水；\nHandling with care.  Damp - proof、           water proof\n√防火；            √  防变形；            √  防撞击；\nfire proof             preventing distortion      preventing impact\n√防压；             √   建议室内存放。       √ 平稳移动\npreventing press      storing indoor             Smoothly moving ");
            //rowLas.Height = 100 * 20;
            //#endregion

            ////设置单元格
            //sheet.AddMergedRegion(new CellRangeAddress(11 + dbCount, 11 + dbCount, 0, 19));
            //var rowRemark = sheet.CreateRow(11 + dbCount);
            //rowRemark.CreateCell(0).SetCellValue("备注：管束运输工装为HTAC（杭汽辅机）财产，产品安装完毕后HTAC将对工装进行回收，请用户/安装公司拆卸完管束后集中堆放于一处并妥善保管。");
            //rowRemark.Height = 50 * 20;

            //sheet.AddMergedRegion(new CellRangeAddress(12 + dbCount, 12 + dbCount, 0, 19));
            //sheet.CreateRow(12 + dbCount);

            //sheet.AddMergedRegion(new CellRangeAddress(13 + dbCount, 13 + dbCount, 0, 19));
            //var rowLink = sheet.CreateRow(13 + dbCount);
            //rowLink.CreateCell(0).SetCellValue(@"发货人：   苏其高   13806476386     鲁G.46786                        收货人：");


            //#region 样式处理
            //ICellStyle style = workbook.CreateCellStyle();
            //style.BorderBottom = BorderStyle.Thin;
            //style.BorderLeft = BorderStyle.Thin;
            //style.BorderRight = BorderStyle.Thin;
            //style.BorderTop = BorderStyle.Thin;
            //style.BottomBorderColor = HSSFColor.Black.Index;
            //style.LeftBorderColor = HSSFColor.Black.Index;
            //style.RightBorderColor = HSSFColor.Black.Index;
            //style.TopBorderColor = HSSFColor.Black.Index;
            //style.Alignment = HorizontalAlignment.Center;
            //style.VerticalAlignment = VerticalAlignment.Center;
            //style.WrapText = true;
            //for (var i = 0; i < 15; i++)
            //{
            //    var rowCell = sheet.GetRow(i);
            //    for (var j = 0; j <= 19; j++)
            //    {
            //        NPOI.SS.UserModel.ICell singleCell = HSSFCellUtil.GetCell(rowCell, (short)j);
            //        singleCell.CellStyle = style;
            //    }
            //}

            //ICellStyle style0 = workbook.CreateCellStyle();
            //style0.BorderBottom = BorderStyle.Thin;
            //style0.BorderLeft = BorderStyle.Thin;
            //style0.BorderRight = BorderStyle.Thin;
            //style0.BorderTop = BorderStyle.Thin;
            //style0.BottomBorderColor = HSSFColor.Black.Index;
            //style0.LeftBorderColor = HSSFColor.Black.Index;
            //style0.RightBorderColor = HSSFColor.Black.Index;
            //style0.TopBorderColor = HSSFColor.Black.Index;
            //style0.Alignment = HorizontalAlignment.Center;
            //style0.VerticalAlignment = VerticalAlignment.Center;
            //style0.WrapText = true;
            ////新建一个字体样式对象
            //IFont font = workbook.CreateFont();
            ////设置字体加粗样式
            //font.IsBold = true;
            ////使用SetFont方法将字体样式添加到单元格样式中 
            //style0.SetFont(font);

            //var dd = sheet.GetRow(7);
            //dd.GetCell(0).CellStyle = style0;

            ////设置列宽
            //sheet.SetColumnWidth(0, 6 * 256);
            //sheet.SetColumnWidth(1, 10 * 256);
            //sheet.SetColumnWidth(2, 6 * 256);
            //sheet.SetColumnWidth(3, 3 * 256);
            //sheet.SetColumnWidth(4, 2 * 256);
            //sheet.SetColumnWidth(5, 1 * 256);
            //sheet.SetColumnWidth(6, 7 * 256);
            //sheet.SetColumnWidth(7, 5 * 256);
            //sheet.SetColumnWidth(8, 5 * 256);
            //sheet.SetColumnWidth(9, 7 * 256);
            //sheet.SetColumnWidth(10, 2 * 256);
            //sheet.SetColumnWidth(11, 3 * 256);
            //sheet.SetColumnWidth(12, 2 * 256);
            //sheet.SetColumnWidth(13, 8 * 256);
            //sheet.SetColumnWidth(14, 5 * 256);
            //sheet.SetColumnWidth(15, 4 * 256);
            //sheet.SetColumnWidth(16, 4 * 256);
            //sheet.SetColumnWidth(17, 5 * 256);
            //sheet.SetColumnWidth(18, 6 * 256);
            //sheet.SetColumnWidth(19, 10 * 256);
            //#endregion

            //var file = new FileStream($"d:\\{DateTime.Now:ddHHmmss}.xls", FileMode.Create);
            //workbook.Write(file);
            //file.Close(); 
            #endregion

            #region 文件占用处理
            // string vFileName = @"C:\Users\admin\Desktop\新建文件夹\1.txt";
            // if (!File.Exists(vFileName))
            // {
            //    // MessageBox.Show("文件都不存在!");
            //     return;
            // }
            // IntPtr vHandle = _lopen(vFileName, OF_READWRITE | OF_SHARE_DENY_NONE);
            // if (vHandle == HFILE_ERROR)
            // {
            //    // MessageBox.Show("文件被占用！");
            //     return;
            // }
            // CloseHandle(vHandle);
            //// MessageBox.Show("没有被占用！"); 
            #endregion

            #region ASP.NET访问网络映射盘&实现文件上传读取功能
            //var nfsText = File.ReadAllText( @"/nfs.config", Encoding.UTF8);
            //var nfsJson = JsonConvert.DeserializeObject<dynamic[]>(nfsText);

            //uint state = 0;
            //if (!Directory.Exists("Z:"))
            //{
            //    state = WNetHelper.WNetAddConnection(@"admin", "654321", @"\\192.168.1.122\down.maidiyun.com", "Z:");
            //}
            //if (state.Equals(0))
            //{
            //    //创建共享目录的上传路径
            //    if (!Directory.Exists("Z:\\UpLoad"))
            //    {
            //        Directory.CreateDirectory("Z:\\UpLoad");
            //    }
            //}
            //else
            //{
            //    System.IO.File.AppendAllText("d:\\nfs.log", "添加网络驱动器错误，错误号：" + state.ToString() + "\r\n");
            //} 
            #endregion

            //var a = 2 << 3;

            //Console.WriteLine(a);

            //for (int i = 0; i < 1; ++i)
            //{
            //    Console.WriteLine(i);
            //}
            //信鸽通信
            //Console.WriteLine(XingeApp.XingeApp.pushTokenAndroid(2100240957, "f255184d160bad51b88c31627bbd9530", "title", "android来自C# SDK的单个设备推测试消息", "76501cd0277cdcef4d8499784a819d4772e0fdde"));

            #region 系统蜂鸣音
            //if (Beep(3000, 5000))
            //{
            //    Console.WriteLine("成功");
            //}
            //else
            //{
            //    Console.WriteLine("失败");
            //}
            //var a= APIs.MessageBeep(0x00000040);

            //Interaction.Beep();
            //APIs.PlaySound(@"D:\Users\admin\AppData\Roaming\baidu\BaiduNetdisk\sounds\4.wav", 0, 1); //把1替换成9，可连续播放   
            #endregion
            


            Console.WriteLine("ok");
            Console.ReadKey();
        }
        

        public static bool Beep(int iFrequency, int iDuration)
        {
            return APIs.Beep(iFrequency, iDuration);
        }

        public class APIs
        {
            [DllImport("Kernel32.dll")]
            public static extern bool Beep(int frequency, int duration);

            [DllImport("user32.dll")]
            public static extern int MessageBeep(uint uType);
            //发出不同类型的声音的参数如下：  
            //Ok = 0x00000000,  
            //Error = 0x00000010,  
            //Question = 0x00000020,  
            //Warning = 0x00000030,  
            //Information = 0x00000040  

            [DllImport("winmm.dll")]
            public static extern bool PlaySound(String Filename, int Mod, int Flags);
        }


        /// <summary>
        /// 设置单元格样式
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cell"></param>
        private static void setCellStyle(IWorkbook workbook, NPOI.SS.UserModel.ICell cell)
        {
            ICellStyle style0 = workbook.CreateCellStyle();
            style0.BorderBottom = BorderStyle.Thin;
            cell.CellStyle = style0;
            //var fCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            //var ffont = (XSSFFont)workbook.CreateFont();
            ////ffont.FontHeight = 20 * 20;
            //ffont.FontName = "宋体";
            //ffont.Color =new XSSFColor();
            //fCellStyle.SetFont(ffont);

            //fCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//垂直对齐
            //fCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//水平对齐
            //cell.CellStyle = fCellStyle;
        }


        private static int preNumber = 0;
        private static string prePath = "";
        public static void CreateWJJ(IList<Dictionary<string, object>> list, string path = "F:\\Demo")
        {
            var a = 1;
            foreach (var li in list)
            {
                var path1 = path + "\\" + a + li["Title"];
                var dir = new DirectoryInfo(path1);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                if (li.ContainsKey("Kids")) // True
                {
                    CreateWJJ((IList<Dictionary<string, object>>)li["Kids"], path1);
                }
                else
                {
                    SavePic(path1, int.Parse(li["Page"].ToString().Split(' ')[0]));
                }
                a++;
            }
        }

        public static void SavePic(string path, int number)
        {
            var device = new Aspose.Pdf.Devices.JpegDevice(80);
            using (var document = new Aspose.Pdf.Document("F:\\navicat.pdf"))
            {
                //图片的路径及名称
                var ImgPath = path + "\\" + number + ".jpg";
                using (var fs = new FileStream(ImgPath, FileMode.OpenOrCreate))
                {
                    device.Process(document.Pages[number], fs);
                    fs.Close();
                }
            }
            if (preNumber > 0 && number - preNumber > 1)
            {
                using (var document = new Aspose.Pdf.Document("F:\\navicat.pdf"))
                {
                    for (int i = 1; i < number - preNumber; i++)
                    {
                        //图片的路径及名称
                        var ImgPath = prePath + "\\" + (preNumber + i) + ".jpg";
                        using (var fs = new FileStream(ImgPath, FileMode.OpenOrCreate))
                        {
                            device.Process(document.Pages[preNumber + i], fs);
                            fs.Close();
                        }
                    }

                }
            }
            preNumber = number;
            prePath = path;
        }

        private static string readPDF(string fn)
        {
            PdfReader p = new PdfReader(fn);
            //从每一页读出的字符串
            string str = String.Empty;
            //"[......]"内部字符串
            string subStr = String.Empty;
            //函数返回的字符串
            string rtStr = String.Empty;
            //从每一页读出的8位字节数组
            byte[] b = new byte[0];
            //"[","]","(",")"在字符串中的位置
            Int32 bg = 0, ed = 0, subbg = 0, subed = 0;
            //取得文档总页数
            int pg = p.NumberOfPages;
            for (int i = 1; i <= pg; i++)
            {
                bg = 0;
                ed = 0;
                Array.Resize(ref b, 0);
                //取得第i页的内容
                b = p.GetPageContent(i);
                //下一行是把每一页的取得的字节数据写入一个txt的文件,仅供研究时用
                //System.IO.File.WriteAllBytes(Application.StartupPath + "//P" + i.ToString() + ".txt", b);
                StringBuilder sb = new StringBuilder();

                //取得每一页的字节数组,将每一个字节转换为字符,并将数组转换为字符串
                for (int j = 0; j < b.Length; j++) sb.Append(Convert.ToChar(b[j]));
                str = sb.ToString();
                //循环寻找"["和"]",直到找不到"["为止
                while (bg > -1)
                {
                    //取得下一个"["和"]"的位置
                    bg = str.IndexOf("[", ed);
                    ed = str.IndexOf("]", bg + 1);
                    //如果没有下一个"["就跳出循环
                    if (bg == -1) break;
                    //取得一个"[]"里的内容,将开始寻找"("和")"的位置初始为0
                    subStr = str.Substring(bg + 1, ed - bg - 1);
                    subbg = 0;
                    subed = 0;
                    //循环寻找下一个"("和")",直到没有下一个"("就跳出循环
                    while (subbg > -1)
                    {
                        //取得下一对"()"的位置
                        subbg = subStr.IndexOf("(", subed);
                        subed = subStr.IndexOf(")", subbg + 1);
                        //如找不到下一对就跳出
                        if (subbg == -1) break;
                        //在返回字符串后面加上新找到的字符串
                        rtStr += subStr.Substring(subbg + 1, subed - subbg - 1);
                    }
                }
            }
            //PDF文档中读出来的数据没有换行符,可以根据需要把2个或3个连续的空格改成换行符
            rtStr = rtStr.Replace("  ", "/r/n");
            return rtStr;
        }

        public class Goods
        {
            public string ProdName { get; set; }
            public string SkuName { get; set; }
            public int Num { get; set; }
            public double ZhongLiang { get; set; }
        }

        public static void testFun(object obj)
        {
            sema.WaitOne();
            Console.WriteLine(obj.ToString() + "____IN" + DateTime.Now.ToString());
            Thread.Sleep(5000);
            Console.WriteLine(obj.ToString() + "__________OUT" + DateTime.Now.ToString());
            sema.Release();
        }

        private Queue m_inputQueue;
        public Program()
        {
            m_inputQueue = new Queue();
        }

        //Add an element to the queue and obtain the monitor lock for the queue object.
        public void AddElement(object qValue)
        {
            //Lock the queue.
            Monitor.Enter(m_inputQueue);
            //Add element
            m_inputQueue.Enqueue(qValue);
            //Unlock the queue.
            Monitor.Exit(m_inputQueue);
        }

        //Try to add an element to the queue.
        //Add the element to the queue only if the queue object is unlocked.
        public bool AddElementWithoutWait(object qValue)
        {
            //Determine whether the queue is locked 
            if (!Monitor.TryEnter(m_inputQueue))
                return false;
            m_inputQueue.Enqueue(qValue);

            Monitor.Exit(m_inputQueue);
            return true;
        }

        //Try to add an element to the queue. 
        //Add the element to the queue only if during the specified time the queue object will be unlocked.
        public bool WaitToAddElement(object qValue, int waitTime)
        {
            //Wait while the queue is locked.
            if (!Monitor.TryEnter(m_inputQueue, waitTime))
                return false;
            m_inputQueue.Enqueue(qValue);
            Monitor.Exit(m_inputQueue);

            return true;
        }

        //Delete all elements that equal the given object and obtain the monitor lock for the queue object.
        public void DeleteElement(object qValue)
        {
            //Lock the queue.
            Monitor.Enter(m_inputQueue);
            int counter = m_inputQueue.Count;
            while (counter > 0)
            {
                //Check each element.
                object elm = m_inputQueue.Dequeue();
                if (!elm.Equals(qValue))
                {
                    m_inputQueue.Enqueue(elm);
                }
                --counter;
            }
            //Unlock the queue.
            Monitor.Exit(m_inputQueue);
        }

        //Print all queue elements.
        public void PrintAllElements()
        {
            //Lock the queue.
            Monitor.Enter(m_inputQueue);
            IEnumerator elmEnum = m_inputQueue.GetEnumerator();
            while (elmEnum.MoveNext())
            {
                //Print the next element.
                Console.WriteLine(elmEnum.Current.ToString());
            }
            //Unlock the queue.
            Monitor.Exit(m_inputQueue);
        }


        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            WebClient client = new WebClient
            {
                Encoding = System.Text.Encoding.GetEncoding("utf-8")
            };

            var html = client.DownloadString("http://i3.maidiyun.com/platform/laser-code.html?v=1.0");
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "......" + "未签。");
            if (html.IndexOf("待售") != -1)
            {
                if (timer != null)
                    timer.Stop();

                // 发送5条短信
                for (int i = 0; i < 5; i++)
                {
                    // 发送短信
                    //SmsMessage.Send("152****7178", "SMS_92310001", new { name = "Emrys", status = "恭喜恭喜恭喜，房子已签售！" });
                    Thread.Sleep(5 * 1000);
                }

            }
        }


        static async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "<key>");//Face API key

            // Request parameters
            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "false";
            queryString["returnFaceAttributes"] = "age";
            var uri = "https://api.cognitive.azure.cn/face/v1.0/detect?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"url\":\"http://imgsrc.baidu.com/baike/pic/item/4034970a304e251ff1e3819aa486c9177f3e53bf.jpg\"}");//图片URL

            using (var content = new ByteArrayContent(byteData))
            {
                response = await client.PostAsync(uri, content);
            }

            //response result
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine("response:" + result);
        }


        public class MyClass
        {
            public string vasdfasdfal { get; set; }
            public int? val { get; set; }
        }
        public class MyClass1
        {
            public string aaaaaa { get; set; }
            public int valb { get; set; }
        }

        public void RunMe()
        {
            Console.WriteLine("RunMe called");
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

    class Account
    {
        private object thisLock = new object();
        int balance;
        Random r = new Random();

        public Account(int initial)
        {
            balance = initial;
        }

        int Withdraw(int amount)
        {
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }
            lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine("Balance before Withdrawal :  " + balance);
                    Console.WriteLine("Amount to Withdraw        : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after Withdrawal  :  " + balance);
                    return amount;
                }
                else
                {
                    return 0; // transaction rejected
                }
            }
        }

        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }
}
