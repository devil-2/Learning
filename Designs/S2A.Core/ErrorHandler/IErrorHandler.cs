using System;

namespace S2A.Core
{
    /// <summary>
    /// Handles exceptions when they are caught and passed to the exception handler
    /// </summary>
    public interface IErrorHandler
    {
        /// <summary>
        /// Handles the given exception
        /// </summary>
        /// <param name="exception">The exception to handle</param>
        void HandleError(Exception exception);
    }
}
