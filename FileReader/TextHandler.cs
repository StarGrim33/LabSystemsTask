namespace FileReader
{
    internal class TextHandler
    {
        private static readonly int _maxWordLength = 50;

        public static async Task<List<string>> PreprocessTextAsync(string filePath)
        {
            try
            {
                string text = await Reader.ReadFile(filePath);
                return PreprocessTextInternal(text);
            }
            catch (Exception ex)
            {
                await Constants.logger.LogAsync($"Произошла ошибка: {ex.Message}");
                throw new Exception($"Ошибка при предварительной обработке текста: {ex.Message}");
            }
        }

        public static List<WordCountEntry> CountWords(List<string> words)
        {
            List<WordCountEntry> result = [];

            foreach (string word in words)
            {
                var entry = result.Find(w => w.Word == word);

                if (entry != null)
                    entry.Count++;
                else
                    result.Add(new WordCountEntry { Word = word, Count = 1});
            }

            return result;
        }

        public static List<WordCountEntry> SortResults(List<WordCountEntry> results)
        {
            return [.. results.OrderByDescending(word => word.Count).ThenBy(word => word.Word)];
        }

        private static List<string> PreprocessTextInternal(string text)
        {
            string lowerCase = text.ToLower();
            return lowerCase.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(word => word.Trim()).
                Where(word => word.All(char.IsLetter) && word.Length <= _maxWordLength).ToList();
        }
    }
}
