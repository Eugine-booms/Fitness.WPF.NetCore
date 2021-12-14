
using Microsoft.EntityFrameworkCore.Diagnostics;

using System;
using System.Data.Common;
using System.IO;

namespace Microsoft.Extensions.Logging
{
    class FileLogger : ILogger , IDisposable
    {
        private string filePath;
        private static object _lock = new object();

        public FileLogger(string filePath)
        {
            this.filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
                }
            }
        }

        public void Dispose()
{
            filePath = null;
            _lock = null;
        }
    }
}
