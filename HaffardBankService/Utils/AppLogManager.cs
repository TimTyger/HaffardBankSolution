using Microsoft.Extensions.Logging;
using NLog;

namespace HaffardBankWebApp.Utils
{
    public class AppLogManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void LogInfo(string method, string message)
        {
            logger.Info($"Method : {method} | {message.Replace('\r', '_').Replace('\n', '_')}");
        }

        public static void LogError(string method, string message)
        {
            logger.Error($"Method : {method} | {message.Replace('\r', '_').Replace('\n', '_')}");
        }

        public static void LogException(string method, Exception ex)
        {
            var error = $"Method : {method} | {ex.Message} \r\n {ex.StackTrace}";
            if (ex.InnerException != null)
            {
                error += $"\r\nInner Exception : {ex.InnerException.Message} \r\n{ex.InnerException.StackTrace}";
            }

            logger.Error(error);
        }
    }
}
