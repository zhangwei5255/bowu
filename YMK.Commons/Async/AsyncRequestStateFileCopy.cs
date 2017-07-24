using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace YMK.Commons.Async
{
    public class AsyncRequestStateFileCopy
    {
             // data that tracks each async request
        public byte[] Buffer; // IO buffer to hold read/write data
        public AutoResetEvent ReadLaunched; // Event signals start of read
        public long bufferOffset; // buffer strides thru file BUFFERS*BUFFER_SIZE
        public IAsyncResult ReadAsyncResult;// handle for read requests to EndRead() on.
        public static Object WriteCountMutex = new Object[0]; // mutex to protect count
        int BUFFER_SIZE;
        int BUFFERS;
        public AsyncRequestStateFileCopy(AsyncFileCopyBean bean)
        { // constructor
            int i = bean.ThreadId;
            BUFFER_SIZE = bean.BUFFER_SIZE;
            BUFFERS = bean.BUFFERS;
            bufferOffset = i * BUFFER_SIZE; // offset in file where buffer reads/writes
            ReadLaunched = new AutoResetEvent(false); // semaphore says reading (not writing)
            Buffer = new byte[BUFFER_SIZE]; // allocates the buffer
        }

        public  void WriteCompleteCallback(IAsyncResult ar)
        {
            lock (WriteCountMutex)
            { // protect the shared variables
                AsyncFileCopyBean bean = ar.AsyncState as AsyncFileCopyBean; // get request index
                int i = bean.ThreadId;
                bean.Target.EndWrite(ar); // mark the write complete
                bean.BytesWritten += BUFFER_SIZE; // advance bytes written
                this.bufferOffset += BUFFERS * BUFFER_SIZE; // stride to next slot
                if (this.bufferOffset < bean.TotalBytes)
                { // if not all read, issue next read
                    bean.Source.Position = this.bufferOffset; // issue read at that offset
                    this.ReadAsyncResult = bean.Source.BeginRead(this.Buffer, 0, BUFFER_SIZE, null, i);
                    this.ReadLaunched.Set();
                }
            }
        }
    }
}
