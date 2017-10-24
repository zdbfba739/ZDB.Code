using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace ZDB.QuartzW
{
    class Program
    {
        static void Main(string[] args)
        {
            //调度器
            IScheduler scheduler;
            //调度器工厂
            ISchedulerFactory factory;

            //创建一个调度器
            factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<TimeJob>().WithIdentity("job1", "group1").Build();

            ITrigger trigger = TriggerBuilder.Create()
               .WithIdentity("trigger1", "group1")
               .WithCronSchedule("0/5 * * * * ?")     //5秒执行一次
                                                      //.StartAt(runTime)
               .Build();

            //4、将任务与触发器添加到调度器中
            scheduler.ScheduleJob(job, trigger);
            //5、开始执行
            scheduler.Start();

        }
    }
}
