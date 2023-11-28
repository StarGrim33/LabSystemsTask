namespace FileReader
{
    internal class Writer
    {
        public static async Task WriteFile(string filePath, LinkedList<WordCountEntry> sortedResults)
        {
            try
            {
                using StreamWriter writer = new(filePath);

                sortedResults.ForEach(async word => await writer.WriteLineAsync($"{word.Word} + {word.Count}"));

                Console.WriteLine("File written");
            }
            catch (Exception ex)
            {
                await Constants.logger.LogAsync($"Произошла ошибка: {ex.Message}");
                throw new Exception($"Ошибка при записи в файл {filePath}: {ex.Message}");
            }
        }
    }
}
