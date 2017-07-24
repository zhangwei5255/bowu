using System;
using System.Threading;
using YMK.Commons.Async;
using System.Collections.Generic;
public class AsyncRequestStateTest : BaseAsyncRequestState
{
    private int _fibOfN;
        private  string strlock = String.Empty;
    /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="ctx">A HttpContext object</param>
        /// <param name="cb">Callback function</param>
        /// <param name="extraData">Extra data</param>
    public AsyncRequestStateTest(
            object extraData)
        : base(extraData)
        {
           
        }

    

    public override void ThreadPoolCallback(object threadContext)
    {
        //lock (strlock)
        //{
            int threadIndex = (int)threadContext;
            Console.WriteLine("thread {0} started...", threadIndex);
            Random r = new Random();
            _fibOfN = Calculate(r.Next(20, 40));
            Console.WriteLine("thread {0} result calculated...", threadIndex); 
        //}

        //this.CompleteRequest();
       
        
    }

    public int Calculate(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        return Calculate(n - 1) + Calculate(n - 2);
    }
}

public class ThreadPoolExample2
{
    static void Main()
    {
        const int LEN = 20;

        List<AsyncRequestStateTest> lstAsyncRequest = new List<AsyncRequestStateTest>();
        for (int i = 0; i < LEN; i++)
        {
            AsyncRequestStateTest asyncRequest = new AsyncRequestStateTest(i);
            lstAsyncRequest.Add(asyncRequest);
        }

        ThreadPoolExt threadPoolExt = new ThreadPoolExt(lstAsyncRequest.ToArray());
        //threadPoolExt.QueueUserWorkItemByParallel();
        threadPoolExt.QueueUserWorkItemBySeries();
        threadPoolExt.WaitAllCompleted();

        Console.WriteLine("All calculations are complete.");

        Console.Read();
    }
}