using System;
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

        public void TaskWaitVsAsyncAwaitTask() {
            taskWaitVsAsyncAwait1();
            Console.WriteLine("Hey I WANTED do something else first!");
        }
        public void TaskWaitVsAsyncAwaitAsync()
        {
            taskWaitVsAsyncAwait2();
            Console.WriteLine("Hey Thanks for letting me do something else first!!");
        }

        private void taskWaitVsAsyncAwait1()
        {
            Task t = Task.Factory.StartNew(DoSomethingThatTakesTime);
            t.Wait();
            //thread will wait for the task to be completed
            Console.WriteLine("Task Wait call finished");
        }

        private async void taskWaitVsAsyncAwait2()
        {
            var result = Task.Factory.StartNew(DoSomethingThatTakesTime);
            await result;
            //when the long method returns it will print the result! thred not blocked....
            Console.WriteLine("Async Await call finished");
        }

        private void DoSomethingThatTakesTime()
        {
            Thread.Sleep(10000);
        }

    }
}
