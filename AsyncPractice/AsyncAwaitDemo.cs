using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncPractice
{
    public class AsyncAwaitDemo
    {
        private static AsyncAwaitDemo instance;

        public AsyncAwaitDemo(){}

        public static AsyncAwaitDemo Instance {
            get
            {
                if(instance == null)
                {
                    instance = new AsyncAwaitDemo();
                }
                return instance;
            }
        }

        
        public async void AwaitAll()
        {
            Task<int> result1 = Task.Factory.StartNew(()=> getIntWithDelay(1));
            Task<int> result2 = Task.Factory.StartNew(() => getIntWithDelay(2));
            Task<int> result3 = Task.Factory.StartNew(() => getIntWithDelay(3));

            int[] results = await Task.WhenAll( result1, result2, result3 );
            //note that it just wait for every three to be finished. It doesn't care of order they are finished.
            Console.WriteLine("Async Await every calls finished in this order: " + String.Join(",", results));            
        }

        public async void AwaitAny() {
            Task<int> result1 = Task.Factory.StartNew(() => getIntWithDelay(1));
            Task<int> result2 = Task.Factory.StartNew(() => getIntWithDelay(2));
            Task<int> result3 = Task.Factory.StartNew(() => getIntWithDelay(3));

            Task<int> resultTask = await Task.WhenAny(result1, result2, result3);
            int result = await resultTask;
            Console.WriteLine("the first finished result: "+result);
        }

        public async void AwaitInOrder()
        {
            Task<int> result1 = Task.Factory.StartNew(() => getIntWithDelay(1));
            Task<int> result2 = Task.Factory.StartNew(() => getIntWithDelay(2));
            Task<int> result3 = Task.Factory.StartNew(() => getIntWithDelay(3));
            
            List<int> listResult = new List<int>();

            var listTask = new[] { result1, result2, result3 };
            var processingTasks = listTask.Select(async t => 
            {
                int result = await t;
                listResult.Add(result);
            }).ToArray();
            await Task.WhenAll(processingTasks);

            Console.WriteLine("Async Await every calls finished in this order: " + String.Join(",", listResult));
        }



        private int getIntWithDelay(int x)
        {
            Random rnd = new Random();
            int rInt = rnd.Next(1, 11);  // >= 1 and < 11
            Thread.Sleep(100*rInt);
            return x;
        }


    }
}
