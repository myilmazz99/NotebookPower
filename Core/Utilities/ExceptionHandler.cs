using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public static class ExceptionHandler
    {
        public static async Task<T> HandleExceptionWithData<T>(Func<Task<T>> method)
        {
            try
            {
                var data = await method.Invoke();
                if (data == null)
                {
                    throw new Exception("No data.");
                }
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task HandleException(Func<Task> method)
        {
            try
            {
                await method.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
