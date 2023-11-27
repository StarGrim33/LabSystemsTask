namespace FileReader
{
    internal class TextHandler
    {
        private static readonly int _maxWordLength50;

        public static async Task<List<string>> PreprocessTextAsync(string filePath)
        {
            try
            {
                string text = await Reader.ReadFile(filePath);
                return PreprocessTextInternal(text);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при предварительной обработке текста: {ex.Message}");
            }
        }

        //public static async Task<List<WordCountEntry>> CountWords(List<string> words)
        //{
        //    List<WordCountEntry> result = [];

        //    foreach (string word in words)
        //    {

        //    }
        //}

        private static List<string> PreprocessTextInternal(string text)
        {
            return text.Split().Select(word => word.Trim()).Where(word => word.All(char.IsLetter) && word.Length <= _maxWordLength50).ToList();
        }
    }
}
