namespace FileReader
{
    internal class Reader
    {
        public static async Task<string> ReadFile(string filePath)
        {
            try
            {
                using StreamReader reader = new(filePath);
                string content = await reader.ReadToEndAsync();
                return content;
            }
            catch (Exception ex)
            {
                await Constants.logger.LogAsync($"Произошла ошибка: {ex.Message}");
                throw new Exception($"Ошибка при чтении файла {filePath}: {ex.Message}");
            }
        }
    }
}
