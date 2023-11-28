namespace FileReader
{
    internal class TextHandler
    {
        private static readonly int _maxWordLength = 50;

        public static async Task<LinkedList<string>> PreprocessTextAsync(string filePath)
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

        public static LinkedList<WordCountEntry> CountWords(LinkedList<string> words)
        {
            LinkedList<WordCountEntry> result = new();

            words.ForEach(word =>
            {
                var entryNode = result.Find(node => node.Word == word);

                if (entryNode != null)
                    entryNode.Data.Count++;
                else
                    result.Add(new WordCountEntry { Word = word, Count = 1 });
            });

            return result;
        }


        public static LinkedList<WordCountEntry> SortResults(LinkedList<WordCountEntry> results)
        {
            List<WordCountEntry> sortedList = results.ToList();

            sortedList = sortedList.OrderByDescending(entry => entry.Count)
                                  .ThenBy(entry => entry.Word)
                                  .ToList();

            LinkedList<WordCountEntry> sortedLinkedList = new();

            foreach (var entry in sortedList)
                sortedLinkedList.Add(entry);

            return sortedLinkedList;
        }

        private static LinkedList<string> PreprocessTextInternal(string text)
        {
            string lowerCase = text.ToLower();

            List<string> words = lowerCase
                .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.Trim())
                .Where(word => word.All(char.IsLetter) && word.Length <= _maxWordLength)
                .ToList();

            LinkedList<string> result = new();
            words.ForEach(word => result.Add(word));

            return result;
        }
    }
}
