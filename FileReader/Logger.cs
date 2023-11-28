using FileReader.Interfaces;

namespace FileReader
{
    internal class Logger : ILogger
    {
        private readonly string _logFilePath;

        public Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public async Task LogAsync(string message)
        {
            using StreamWriter logFile = File.AppendText(_logFilePath);
            await logFile.WriteLineAsync($"{DateTime.Now}: {message}");
        }
    }
}
