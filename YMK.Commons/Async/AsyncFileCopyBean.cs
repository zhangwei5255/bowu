using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace YMK.Commons.Async
{
    public class AsyncFileCopyBean
    {
        private int _threadId;        //スレッドのID
        private FileStream _source; // source file stream
        private FileStream _target; // target file stream
        private long _totalBytes; // total bytes to process
        private long _bytesRead; // bytes read so far
        private long _bytesWritten; // bytes written so far
        private int _BUFFERS;       //number of outstanding requests
        private int _BUFFER_SIZE;   // request size, one megabyte

        /// <summary>
        /// スレッドのID
        /// </summary>
        public int ThreadId
        {
            get
            {
                return _threadId;
            }
            set
            {
                _threadId = value;
            }
        }

        /// <summary>
        ///  source file stream
        /// </summary>
        public FileStream Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
            }
        }

        /// <summary>
        ///  target file stream
        /// </summary>
        public FileStream Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }

        /// <summary>
        ///  total bytes to process
        /// </summary>
        public long TotalBytes
        {
            get
            {
                return _totalBytes;
            }
            set
            {
                _totalBytes = value;
            }
        }

        /// <summary>
        ///  bytes read so far
        /// </summary>
        public long BytesRead
        {
            get
            {
                return _bytesRead;
            }
            set
            {
                _bytesRead = value;
            }
        }

        /// <summary>
        ///  bytes written so far
        /// </summary>
        public long BytesWritten
        {
            get
            {
                return _bytesWritten;
            }
            set
            {
                _bytesWritten = value;
            }
        }

        /// <summary>
        /// number of outstanding requests
        /// </summary>
        public int BUFFERS
        {
            get
            {
                return _BUFFERS;
            }
            set
            {
                _BUFFERS = value;
            }
        }

        /// <summary>
        ///  request size, one megabyte
        /// </summary>
        public int BUFFER_SIZE
        {
            get
            {
                return _BUFFER_SIZE;
            }
            set
            {
                _BUFFER_SIZE = value;
            }
        }
    }
}
