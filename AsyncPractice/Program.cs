﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            //TaskWaitDemo.Instance.SimpleDelay();
            //TaskWaitDemo.Instance.TaskWaitVsAsyncAwaitTask();
            //TaskWaitDemo.Instance.TaskWaitVsAsyncAwaitAsync();

            //AsyncAwaitDemo.Instance.AwaitAll();
            //AsyncAwaitDemo.Instance.AwaitAny();
            AsyncAwaitDemo.Instance.AwaitInOrder();
            

            Console.WriteLine("***Program Ended***");
            Console.ReadLine();





        }



    }
}
