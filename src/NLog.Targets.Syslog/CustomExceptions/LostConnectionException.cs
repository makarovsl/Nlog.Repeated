using System;
using System.Threading.Tasks;

namespace NLog.Targets.Syslog.CustomExceptions
{
    /// <summary>
    /// Exception нет соединения с сервером
    /// </summary>
    public class LostConnectionException : Exception
    {
        /// <summary>
        /// Таск на переподключение
        /// </summary>
        public Task ReconnectTask { get; private set; }


        /// <summary>
        /// Конструктор с таской на реконект
        /// </summary>
        /// <param name="reconnectTask">Таска на реконект</param>
        public LostConnectionException(Task reconnectTask)
        {
            ReconnectTask = reconnectTask;
        }


    }
}
