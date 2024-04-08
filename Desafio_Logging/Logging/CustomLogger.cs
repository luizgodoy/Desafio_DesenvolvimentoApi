using Microsoft.Extensions.Logging;

namespace Desafio_Logging.Logging
{
    public class CustomLogger : ILogger
    {
        public static bool TryWriteInLogFile { get; set; } = false;
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _loggerConfig;

        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig)
        {
            this._loggerName = loggerName;
            this._loggerConfig = loggerConfig;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = string.Format($"{logLevel}: {eventId.Id} - {formatter(state, exception)}");

            if (TryWriteInLogFile)
                WriteInLogFile(message);

            if (logLevel.Equals(LogLevel.Information))
                Console.WriteLine(message);
        }

        private void WriteInLogFile(string mensagem)
        {
            string logFilePath = Environment.CurrentDirectory + @$"\Log\LOG-{DateTime.Now:yyyy-MM-dd}.txt";

            if (!File.Exists(logFilePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
                File.Create(logFilePath).Dispose();
            }

            using StreamWriter streamWriter = new(logFilePath, true);
            streamWriter.WriteLine(mensagem);
            streamWriter.Close();
        }
    }
}