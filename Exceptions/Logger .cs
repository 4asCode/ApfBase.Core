using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Exceptions
{
    public class Logger
    {
        public Logger(Exception ex, string message)
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
