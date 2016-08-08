using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
  public class Semaphore : IDisposable
  {
    private static object _lock = new object();
    private static int _active;
    private static int _max = 1;

    public static int Max
    {
      get { return _max; }
      set 
      { 
        lock (_lock)
          _max = value; 
      }
    }

    public static int Active
    {
      get { return _active; }
    }

    public Semaphore()
    {
      bool okToRun = false;
      do
      {
        if (_active < _max)
        {
          lock (_lock)
          {
            if (_active < _max)
            {
              _active++;
              Console.WriteLine("+Active " + _active.ToString());
              okToRun = true;
            }
          }
        }
        else
        {
          Console.WriteLine("=Blocked " + _active.ToString());
          Thread.Sleep(2);
        }
      } while (!okToRun);
    }

    public void Dispose()
    {
      lock (_lock)
      {
        Console.WriteLine("-Active " + _active.ToString());
        _active--;
      }
    }
  }
}
