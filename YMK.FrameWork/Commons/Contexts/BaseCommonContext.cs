using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Configuration;
using YMK.FrameWork.Commons.Contexts.Contracts;
using YMK.FrameWork.Commons.Contexts.Utils;

namespace YMK.FrameWork.Commons.Contexts
{
    public abstract class BaseCommonContext:IBaseCommonContext
    {
        public virtual SpringContextWrapper SpringContext
        {
            get {
                return ContextFactory.SpringCfgContext;
            }
        }

        public virtual Object GetObject(string objectName)
        {
            return SpringContext.GetObject(objectName);
        }

    }
}

