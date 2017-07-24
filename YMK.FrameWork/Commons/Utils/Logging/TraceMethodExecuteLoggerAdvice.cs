using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopAlliance.Intercept;
using log4net;

namespace YMK.FrameWork.Commons.Utils.Logging
{
    public class TraceMethodExecuteLoggerAdvice: IMethodInterceptor
    {
        private static readonly ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public object Invoke(IMethodInvocation invocation)
        {
            string message = invocation.Method.ReflectedType.Name + ".";
            message += invocation.Method.Name+"(";
            var paraInfos = invocation.Method.GetParameters();
            if (paraInfos.Length > 0)
            {
                message += paraInfos[0].ParameterType.Name + " " + paraInfos[0].Name;
                for (int i = 1; i < paraInfos.Length; i++)
                {
                    message +="," + paraInfos[i].ParameterType.Name + " " + paraInfos[i].Name;
                }
                message += ")";
            }
            logger.Debug(message + " START.");            
            object returnValue = invocation.Proceed();
            logger.Debug(message +" END.");
            return returnValue;
        }
    
    }
}
