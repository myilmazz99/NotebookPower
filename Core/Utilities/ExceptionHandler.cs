using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public static class ExceptionHandler
    {
        public static IResult HandleException(Action action)
        {
			try
			{
				action.Invoke();
				return new SuccessResult();
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}
