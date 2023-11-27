namespace FileReader
{
    internal class Writer
    {
        public static async Task WriteFile(string filePath, string data)
        {
            try
            {
                using StreamWriter writer = new(filePath);
                await writer.WriteAsync(data);
                Console.WriteLine("File written");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при записи в файл {filePath}: {ex.Message}");
            }
        }
    }
}
