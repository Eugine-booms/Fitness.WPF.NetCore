using System;

namespace Microsoft.Extensions.Logging
{
    class FileLoggerProvider : ILoggerProvider
    {
        private string path;
        public FileLoggerProvider(string path)
        {
            this.path = path;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(path);
        }

        public void Dispose()
        {
            path = null;
           
        }
    }
}
