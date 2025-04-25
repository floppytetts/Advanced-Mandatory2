using System.Diagnostics;

namespace GameFramework.Logging
{
    /// <summary>
    /// Provides logging functionality with different severity levels.
    /// </summary>
    public static class Logger
    {
        /// <summary>Logs an informational message.</summary>
        /// <param name="message">The message to log.</param>
        public static void Info(string message)
        {
            Trace.WriteLine($"[{DateTime.Now:dd-M-yyyy HH:mm:ss}] [INFO] {message}");
        }

        /// <summary>Logs a warning message.</summary>
        /// <param name="message">The message to log.</param>
        public static void Warning(string message)
        {
            Trace.WriteLine($"[{DateTime.Now:dd-M-yyyy HH:mm:ss}] [WARNING] {message}");
        }

        /// <summary>Logs an error message.</summary>
        /// <param name="message">The message to log.</param>
        public static void Error(string message)
        {
            Trace.WriteLine($"[{DateTime.Now:dd-M-yyyy HH:mm:ss}] [ERROR] {message}");
        }
    }

}
