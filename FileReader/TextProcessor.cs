using FileReader.Interfaces;

namespace FileReader
{
    internal class TextProcessor : ITextProcessor
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
