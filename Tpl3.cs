using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TplNetwork
{
    class Tpl3
    {
        static void Main(string[] args)
        {
            Task t1 = new Task( () =>
                                     {
                                         for(int i=0;i<5;i++)
                                         {
                                             Console.WriteLine("Task1 " + i);
                                             Thread.Sleep(3000);
                                         }
                                     });
            Task t2 = new Task(() => Console.WriteLine("Task 2 working"));
            t1.Start();
            t2.Start();
            Console.WriteLine("Waiting for tasks to complete.");
            int taskIndex = Task.WaitAny(t1, t2);
            Console.WriteLine("Task Completed - array index is : ", taskIndex);
            Console.WriteLine("Main method complete");
            Console.Read();
        }
    }
}
