using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace YMK.Commons.Async
{
    //ThreadPool「最大スレッド数：25」
    public class ThreadPoolExt
    {
        private BaseAsyncRequestState[] _arrAsyncRequestState;
        private WaitHandle[] _doneEvents;


        public ThreadPoolExt(BaseAsyncRequestState[] arrAsyncRequestState)
        {
            _arrAsyncRequestState = arrAsyncRequestState;
            _doneEvents = new ManualResetEvent[arrAsyncRequestState.Length];
        }

        public WaitHandle[]  AsyncHandles
        {
            get
            {
                return _doneEvents;
            }
        }

        //パターン１
        public void QueueUserWorkItemByParallel()
        {
            for (int i = 0; i < _arrAsyncRequestState.Length; i++)
            {
                _doneEvents[i] = _arrAsyncRequestState[i].AsyncWaitHandle;
                ThreadPool.QueueUserWorkItem(_arrAsyncRequestState[i].CompleteCallback, i);
            }
        }

        public void QueueUserWorkItemByParallel(Object src)
        {
            for (int i = 0; i < _arrAsyncRequestState.Length; i++)
            {
                _doneEvents[i] = _arrAsyncRequestState[i].AsyncWaitHandle;
                ThreadPool.QueueUserWorkItem(_arrAsyncRequestState[i].CompleteCallback, src);
            }
        }

        public void QueueUserWorkItemByParallel(Object src, int threadNo)
        {
            int i = threadNo;
            if (_doneEvents[i] == null)
            {
                _doneEvents[i] = _arrAsyncRequestState[i].AsyncWaitHandle;
            }

            ThreadPool.QueueUserWorkItem(_arrAsyncRequestState[i].CompleteCallback, src);
        }

        //パターン２
        public void QueueUserWorkItemByTask()
        {
            for (int i = 0; i < _arrAsyncRequestState.Length; i++)
            {
                _doneEvents[i] = _arrAsyncRequestState[i].AsyncWaitHandle;
                ThreadPool.QueueUserWorkItem(_arrAsyncRequestState[i].CompleteLockCallback, i);
            }
        }

        //パターン３
        public void QueueUserWorkItemBySeries()
        {
            for (int i = 0; i < _arrAsyncRequestState.Length; i++)
            {
                _doneEvents[i] = _arrAsyncRequestState[i].AsyncWaitHandle;
                ThreadPool.QueueUserWorkItem(_arrAsyncRequestState[i].CompleteCallback, i);
                //主スレッド待ち
                _arrAsyncRequestState[i].AsyncWaitHandle.WaitOne();
            }
        }

        public void WaitAllCompleted()
        {
            // Wait until all our threads have signaled their wait object is done.
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                // WaitAll for multiple handles on an STA thread is not supported.「_doneEvents[i]繰り返し時」
                // ...so wait on each handle individually.
                foreach (WaitHandle myWaitHandle in this.AsyncHandles)
                {
                    if (myWaitHandle != null)
                    {
                        WaitHandle.WaitAny(new WaitHandle[] { myWaitHandle });
                    }

                }
            }
            else
            {
                WaitHandle.WaitAll(_doneEvents);
            }

            
        }



    }
}
