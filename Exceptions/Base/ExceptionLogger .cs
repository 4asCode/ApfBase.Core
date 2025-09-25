using Serilog;
using System;

namespace Exceptions.Base
{
    public class ExceptionLogger
    {
        public ExceptionLogger(Exception ex, string message)
        {
            Log.Logger = new LoggerConfiguration()
               .WriteTo.File("log//log-.txt",
                    rollingInterval: RollingInterval.Day)
               .CreateLogger();

            try
            {
                Log.Error(ex, message);
            }
            catch (Exception e)
            {
                Log.Error(e, "Ошибка при логировании");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
