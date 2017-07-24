using Spring.Aop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace YMK.FrameWork.Commons.Utils.ExceptionHandler
{

    public class ExceptionAdvice : IThrowsAdvice
    {
        private static readonly ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void AfterThrowing(Exception ex)
        {
            logger.Fatal(ex.Source + "Exception: " + ex.Message);
            logger.Error(ex.StackTrace);
            throw new YmkException(ex);
        }
    }
}
