using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncPractice
{
    public class TaskWaitDemo
    {
        private static TaskWaitDemo instance;

        public TaskWaitDemo(){}

        public static TaskWaitDemo Instance {
            get
            {
                if(instance == null)
                {
                    instance = new TaskWaitDemo();
                }
                return instance;
            }
        }


        public void SimpleDelay()
        {
            Task taskA = new Task(() => {
                Thread.Sleep(2000);
                Console.WriteLine("Hello from taskA");
            });
            taskA.Start();

            //taskA.Wait(); //uncommenting this will print the line from taskA first.

            Console.WriteLine("Print me first");

            taskA.Wait();
        }


        public void WaitAll()
        {
            Task taskA = new Task(() => {
                Thread.Sleep(2000);
                Console.WriteLine("Hello from taskA");
            });
            taskA.Start();

            //taskA.Wait(); //uncommenting this will print the line from taskA first.

            Console.WriteLine("Print me first");

            taskA.Wait();
        }



    }
}
