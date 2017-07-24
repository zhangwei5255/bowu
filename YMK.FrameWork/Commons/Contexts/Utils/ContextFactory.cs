using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using Spring.Context;
using Spring.Context.Support;

namespace YMK.FrameWork.Commons.Contexts.Utils
{
	public class ContextFactory
	{
        static SpringContextWrapper springCfgContext;
		
		public static SpringContextWrapper SpringCfgContext
		{
			get
			{
				if(springCfgContext==null)
				{
                    try
                    {
                        springCfgContext = new SpringContextWrapper();
                        springCfgContext.SpringContext = ContextRegistry.GetContext();
                    }
                    catch(System.Exception ee)
                    { 
                        Console.WriteLine((ee.Message));
                    }
				}
				return springCfgContext;
			}
		}
		
	}

}
