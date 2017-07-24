
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Common.Logging;
using Common.Logging.Log4Net;

namespace YMK.FrameWork.Commons.Utils
{
    public class LogFactory
    {
        static ILog logger;
        public static ILog GetLogger(Type type)
        {
            if (logger == null)
            {
                NameValueCollection properties = new NameValueCollection();
                properties.Add("configType", "FILE-WATCH");
                properties.Add("configFile", @"Resources\log4net.config");
                Log4NetLoggerFactoryAdapter adapter = new Log4NetLoggerFactoryAdapter(properties);
                
                logger = adapter.GetLogger(type);
            }
            return logger;
        }
    }
}
