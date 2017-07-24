using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;

namespace YMK.FrameWork.Commons.Contexts.Utils
{
    public class SpringContextWrapper
    {
        internal IApplicationContext SpringContext { get; set; }       
        //IApplicationContext SpringContext = new XmlApplicationContext("file://C:/JPBook2/Source2013/JPBook2/JPBook2/bin/Debug/Resources/LogicLayerContext.Config");



        public Object GetObject(string name)
        {
            return SpringContext.GetObject(name);
        }

        public bool ContainsObject(string name)
        {
            return SpringContext.ContainsObject(name);
        }

    }
}

