using System;
using static S2A.Core.FrameworkDI;

namespace S2A.Core
{
    /// <summary>
    /// Handles all exceptions, simply logging them to the logger
    /// </summary>
    public class BaseExceptionHandler : IErrorHandler
    {
        /// <summary>
        /// Logs the given exception
        /// </summary>
        /// <param name="exception">The exception</param>
        public void HandleError(Exception exception)
        {
            // Log it
            // TODO: Localization of strings
            Logger.LogCriticalSource("Unhandled exception occurred", exception: exception);
        }
    }
}
