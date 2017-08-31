using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ZDB.DBRepository.DbFactory;
using ZDB.DBRepository.Entity;
using ZDB.GenerateUniqueID;

namespace ZDB.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //var uniqueID = MadeUniqueID.GenerateUniqueID();
            //Console.WriteLine(uniqueID);

            try
            {
                var watch = new Stopwatch();
                watch.Start();
                var uList = new List<UserInfoEntity>();
                for (int i = 1; i <= 1000; i++)
                {
                    uList.Add(new UserInfoEntity
                    {
                        Name = "Name" + i
                    });

                }
                watch.Stop();
                //File.AppendAllLines("D:\\log.txt", new List<string>() { $"加载时间：{watch.ElapsedMilliseconds}毫秒" });
                Console.WriteLine($"加载时间：{watch.ElapsedMilliseconds}毫秒");
                watch.Restart();
               // DbService.BeginTransaction();
                DbService.Insert(uList);
               // DbService.CommitTransaction();
                watch.Stop();
                Console.WriteLine($"提交时间：{watch.ElapsedMilliseconds}毫秒");
            }
            catch (Exception e)
            {
                DbService.RollbackTransaction(e);
                throw;
            }


            Console.Read();
        }
    }
}
