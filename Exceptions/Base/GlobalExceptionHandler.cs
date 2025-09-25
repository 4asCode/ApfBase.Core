using System;
using System.Text;
using System.Threading;

namespace Exceptions.Base
{
    public class GlobalExceptionHandler : Exception
    {
        public static string ThreadException(
            object sender, ThreadExceptionEventArgs e)
        {
            string errorDetails = GetExceptionDetails(e.Exception);

            return errorDetails;
        }

        public static string UnhandledException(
            object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            string errorDetails = GetExceptionDetails(ex);

            return errorDetails;
        }

        public static string GetExceptionDetails(Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Произошла ошибка:");
            sb.AppendLine($"Сообщение: {ex.Message}");
            sb.AppendLine($"Тип исключения: {ex.GetType()}");
            sb.AppendLine($"Метод: {ex.TargetSite}");
            sb.AppendLine($"Источник: {ex.Source}");
            sb.AppendLine($"Стек вызовов: {ex.StackTrace}");

            Exception inner = ex.InnerException;
            while (inner != null)
            {
                sb.AppendLine();
                sb.AppendLine("Внутреннее исключение:");
                sb.AppendLine($"Сообщение: {inner.Message}");
                sb.AppendLine($"Тип исключения: {inner.GetType()}");
                sb.AppendLine($"Метод: {inner.TargetSite}");
                sb.AppendLine($"Источник: {inner.Source}");
                sb.AppendLine($"Стек вызовов: {inner.StackTrace}");
                inner = inner.InnerException;
            }

            return sb.ToString();
        }
    }
}
