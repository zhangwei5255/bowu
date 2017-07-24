using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace YMK.Commons.Async
{
    public abstract class BaseAsyncRequestState
    {

        internal object _extraData;
        private bool _isCompleted = false;
        private ManualResetEvent _callCompleteEvent = null;
        //private IAsyncResult _asyncResult;// handle for read requests to EndRead() on.
        private string strlock = String.Empty;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="ctx">A HttpContext object</param>
        /// <param name="cb">Callback function</param>
        /// <param name="extraData">Extra data</param>
        public BaseAsyncRequestState(
            object extraData)
        {
            _extraData = extraData;
        }

        public abstract void ThreadPoolCallback(Object threadContext);

        public void CompleteLockCallback(Object threadContext)
        {
            lock (strlock)
            {
                ThreadPoolCallback(threadContext);
            }

            //当スレッドを解放する
            this.CompleteRequest();
        }

        public void CompleteCallback(Object threadContext)
        {
           
            ThreadPoolCallback(threadContext);
           
            //当スレッドを解放する
            this.CompleteRequest();
        }

        //public void CompleteCallbackReset(Object threadContext)
        //{
        //    CompleteCallback(threadContext);
        //    this.Reset();
        //}

        /// <summary>
        /// Completes the request.
        /// </summary>
        public void CompleteRequest()
        {
            _isCompleted = true;
            lock (this)
            {
                if (_callCompleteEvent != null)
                    _callCompleteEvent.Set();
            }
           
        }

        public void Reset()
        {
            lock (this)
            {
                if (_callCompleteEvent != null)
                    _callCompleteEvent.Reset();
            }
        }

        #region IAsyncResult interface property implementations

        public object AsyncResult
        {
            get
            { 
                return (_extraData); 
            } 
        }
        public bool CompletedSynchronously
        { 
            get 
            { 
                return (false); 
            } 
        }
        public bool IsCompleted
        { 
            get 
            { 
                return _isCompleted; 
            } 
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                lock (this)
                {
                    if (_callCompleteEvent == null)
                        _callCompleteEvent = new ManualResetEvent(false);

                    return _callCompleteEvent;
                }
            }
        }

        #endregion
    }
}
