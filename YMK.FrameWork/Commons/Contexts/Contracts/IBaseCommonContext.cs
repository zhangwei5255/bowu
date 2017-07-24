using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using YMK.FrameWork.Commons.Contexts.Utils;

namespace YMK.FrameWork.Commons.Contexts.Contracts
{
    public interface IBaseCommonContext
    {
        SpringContextWrapper SpringContext { get; }
        Object GetObject(string objectName);

    }
}

