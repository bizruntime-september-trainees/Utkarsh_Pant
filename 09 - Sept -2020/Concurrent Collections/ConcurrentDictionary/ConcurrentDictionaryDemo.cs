

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.Concurrent;
using System.Linq;
	
   public  class Program
    {  
	
      public static void Main(string[] args) {

ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();
 
 
    Task t1 = Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < 100; ++i)
            {
                dictionary.TryAdd(i.ToString(), i.ToString());
                Thread.Sleep(100);
            }
        });
 
    Task t2 = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(300);
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + "-" + item.Value);
                Thread.Sleep(150);
            }
        });
 
    try
    {
        Task.WaitAll(t1, t2);
    }
    catch (AggregateException ex) // No exception
    {
        Console.WriteLine(ex.Flatten().Message);  
    }
	  }
	}
	