using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      Semaphore.Max = 3;
      for (int i = 0; i < 50; i++)
      {
        System.Threading.ThreadPool.QueueUserWorkItem(DoWork, i);
        //var t = new System.Threading.Thread((o) =>
        //  {
        //    using (new Semaphore())
        //    {
        //      System.Threading.Thread.Sleep(10);
        //      Console.WriteLine(o);
        //    }
        //  });
        //t.Start(i);
      }

      Console.ReadLine();
    }

    private static void DoWork(object o)
    {
      using (new Semaphore())
      {
        System.Threading.Thread.Sleep(100);
        Console.WriteLine(o);
      }
    }
  }
}
