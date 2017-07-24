using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using YMK.Commons.Async;

namespace YMK.Commons.Files
{
    public class FileManager
    {
        public static void Save(String strDir, String fileNm, String strContents)
        {
            //出力先チェック
            if (!Directory.Exists(strDir))
            {
                //ディレクトリ作成
                Directory.CreateDirectory(strDir);
            }

            // The using statement also closes the Stream.
            using (StreamWriter sw = new StreamWriter(strDir + fileNm, false, Encoding.UTF8))
            {
                sw.Write(strContents);
               
            }
        }

        public static String ReadAllText(String filePath)
        {
            String retContents = "";
            //update by I.TYOU 20141112 start
            //// The using statement also closes the Stream.
            //using (StreamReader sr = new StreamReader(filePath, false))
            //{
            //    retContents = sr.ReadToEnd();
            //}

            retContents = File.ReadAllText(filePath);
            //update by I.TYOU 20141112 start
            return retContents;
        }

        public static void Remove(String filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static long GetFileSize(String filePath)
        {
            long lng = 0;
            if (File.Exists(filePath))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
                lng = fi.Length;
            }

            return lng;
        }

        public static long GetFileRowCount(String filePath)
        {
            String[] arr = File.ReadAllLines(filePath);
            return arr.LongLength;
        }

        /// <summary>
        /// ファイルのコピー
        /// File.Copyと比較
        /// 前提：ローカルで3.8Gのファイルをコピーする
        /// 結果：File.Copy　   5分17秒がかかる
        /// 　　　FileManager   4分57秒がかかる
        /// </summary>
        /// <param name="fileSrc"></param>
        /// <param name="fileDes"></param>
        public static void Copy(String fileSrc, String fileDes)
        {
            //// globals
            const int BUFFERS = 4; // number of outstanding requests
            const int BUFFER_SIZE = 1 << 20; // request size, one megabyte
            AsyncFileCopyBean bean = new AsyncFileCopyBean();
            bean.BUFFERS = BUFFERS;
            bean.BUFFER_SIZE = BUFFER_SIZE;

            try
            {
                bean.Source = new FileStream(fileSrc, // open source file
             FileMode.Open, // for read
             FileAccess.Read, //
             FileShare.Read, // allow other readers
             BUFFER_SIZE, // buffer size
             true); // use async
                bean.Target = new FileStream(fileDes, // create target file
                  FileMode.OpenOrCreate, // fault if it exists
                  FileAccess.Write, // will write the file
                  FileShare.None, // exclusive access
                  BUFFER_SIZE, // buffer size
                  true); // use async
                bean.TotalBytes = bean.Source.Length; // Size of source file
                bean.BytesRead = 0;
                bean.BytesWritten = 0;

                AsyncRequestStateFileCopy[] request = new AsyncRequestStateFileCopy[BUFFERS];

                for (int i = 0; i < BUFFERS; i++)
                {
                    bean.ThreadId = i;
                    request[i] = new AsyncRequestStateFileCopy(bean);
                }
                //System.Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm"));
                // launch initial async reads
                for (int i = 0; i < BUFFERS; i++)
                { // no callback on reads.
                    //offset=0時、カレント行から読み込む

                    bean.ThreadId = i;
                    request[i].ReadAsyncResult = bean.Source.BeginRead(request[i].Buffer, 0, BUFFER_SIZE, null, bean);
                    request[i].ReadLaunched.Set(); // say that read is launched
                }
                // wait for the reads to complete in order, process buffer and then write it.
                for (int i = 0; (bean.BytesRead < bean.TotalBytes); i = (i + 1) % BUFFERS)
                {
                    request[i].ReadLaunched.WaitOne(); // wait for flag that says buffer is reading
                    int bytes = bean.Source.EndRead(request[i].ReadAsyncResult); // wait for read complete
                    bean.BytesRead += bytes; // process the buffer <your code goes here>
                    bean.ThreadId = i;
                    bean.Target.BeginWrite(request[i].Buffer, 0, bytes, request[i].WriteCompleteCallback, bean); // write it
                } // end of reader loop

                while (bean.Target.Length != bean.TotalBytes)  // wait for all the writes to complete
                {
                    //main thread
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (bean.Source != null)
                {
                    bean.Source.Close();
                    bean.Source.Dispose();
                }
                if (bean.Target != null)
                {
                    bean.Target.Close(); // close the files
                    bean.Target.Dispose();
                }
               
            }
        }
    }
}
