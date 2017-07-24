using System;
using IBatisNet.DataMapper.TypeHandlers;

namespace YMK.FrameWork.Commons.Utils
{
	public class StringTypeHandlerCallback : ITypeHandlerCallback
	{

		
		public object ValueOf(string nullValue)
		{
			return nullValue;
		}

		public object GetResult(IResultGetter getter)
		{
			try 
			{
				var res= getter.Value.ToString();
				return res;
			}
			catch(IndexOutOfRangeException indexEx)
			{
				return NullValue;
			}
			catch(Exception ee)
			{
				throw new Exception("Unexpected value " + getter.Value.ToString() + 
				" found where a valid string value was expected.");
			}
		}

		public void SetParameter(IParameterSetter setter, object parameter)
		{
			setter.Value = parameter.ToString();
		}
		
		
		public object NullValue
		{
			get { return String.Empty; }
		}
		

	}
}

