namespace FileReader
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            try
            {
                var logger = new Logger(Constants.LOGFILEPATH);
                var words = await TextHandler.PreprocessTextAsync(Constants.FILEPATH);
                var entries = TextHandler.CountWords(words);
                var sorted = TextHandler.SortResults(entries);

                await Writer.WriteFile(Constants.OUTPUTFILEPATH, sorted);
                await logger.LogAsync("Результаты успешно записаны в файл ResultPairs.txt");

                DisplayResults(sorted);
            }
            catch (Exception ex)
            {
                await Constants.logger.LogAsync($"Произошла ошибка: {ex.Message}");
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        static void DisplayResults(LinkedList<WordCountEntry> entries)
        {
            Console.WriteLine("Статистика слов:");
            entries.ForEach(x => Console.WriteLine($"{x.Word}: {x.Count}"));
        }
    }
}
