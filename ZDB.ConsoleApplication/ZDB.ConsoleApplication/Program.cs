using System;
using ZDB.GenerateUniqueID;

namespace ZDB.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var uniqueID = MadeUniqueID.GenerateUniqueID();
            Console.WriteLine(uniqueID);
            Console.Read();
        }
    }
}
