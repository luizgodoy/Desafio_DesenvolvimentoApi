using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Desafio_Logging.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly CustomLoggerProviderConfiguration _LogerConfig;
        private readonly ConcurrentDictionary<string, CustomLogger> _Loggers = new ConcurrentDictionary<string, CustomLogger>();

        public CustomLoggerProvider(CustomLoggerProviderConfiguration _loggerConfig)
        {
            _LogerConfig = _loggerConfig;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _Loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _LogerConfig));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
