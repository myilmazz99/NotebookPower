using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public static class ExceptionHandler
    {
        public static Result HandleException(Action action)
        {
			try
			{
				action.Invoke();
				return new SuccessResult("");
			}
			catch (Exception ex)
			{
				return new ErrorResult(ex.Message);
			}
        }
    }
}
