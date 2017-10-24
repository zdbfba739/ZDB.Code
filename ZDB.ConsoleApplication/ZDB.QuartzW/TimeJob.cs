using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace ZDB.QuartzW
{
    public class TimeJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            System.IO.File.AppendAllText(@"E:\my3Dparts\MyCode\Code\ZDB.Code\ZDB.ConsoleApplication\ZDB.QuartzW\bin\Debug\Quartz.txt", DateTime.Now + Environment.NewLine);
        }
    }
}
