using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZDB.ConsoleApplication
{
    public class MethodToRun
    {
        [Excute(Flag = 1)]
        public static void Run()
        {
            Console.WriteLine("Run Run Hurry Up!");
            Console.ReadLine();
        }
        [CustomFilter]
        public static void Walk()
        {
            Console.WriteLine("Walk Slowly~");
            Console.ReadLine();
        }
        [Excute(Flag = 2)]
        public static void Go()
        {
            Console.WriteLine("Go Go Go!");
            Console.ReadLine();
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ExcuteAttribute : Attribute
    {
        public int Flag { get; set; }
    }

    public interface ICustomFilter
    {
        //Action执行之前执行
        void OnBeforeAction();

        //Action执行之后执行
        void OnAfterAction();
    }

    public class CustomFilterAttribute : Attribute, ICustomFilter
    {
        public void OnAfterAction()
        {
            Console.WriteLine("Action 执行之后进行拦截！");
        }

        public void OnBeforeAction()
        {
            Console.WriteLine("Action 执行之前进行拦截！");
        }
    }
}
