namespace FileReader
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            string filePath = @"C:\Users\Влад и Аня\Desktop\C# course\LabSystemsTask\FileReader\WordsList.txt";
            string outputFilePath = @"C:\Users\Влад и Аня\Desktop\C# course\LabSystemsTask\FileReader\ResultPairs.txt";
            string logFilePath = @"C:\Users\Влад и Аня\Desktop\C# course\LabSystemsTask\FileReader\logfile.txt";

            string dataExample = 
                "Ураган накрыл музей-аквариум в Севастополе. Губернатор города Михаил Развожаев сообщил, " +
                "что «шторм века» не смогли пережить более 500 обитателей музея. Позднее число жертв среди питомцев превысило " +
                "800.\r\n\r\nПо словам главы города, основной удар стихии пришелся на третий зал музея, открытый в 1897 году. " +
                "Кроме того, серьезный ущерб был нанесен Институту биологии южных морей, в котором пострадали несколько научных лабораторий." +
                "\r\n\r\nКоличество пострадавших животных увеличилось\r\n26 ноября около 22:00 поток воды ударил по крыше музея, " +
                "пробив кровлю и смыв вентиляционную систему. По словам очевидцев, с каждой приходящей волной в помещение попадало примерно три куба воды.";

            //await Writer.WriteFile(filePath, dataExample);
            //Task<string> readTask = Reader.ReadFile(filePath);
            //await readTask;

            try
            {
                string text = await Reader.ReadFile(filePath);
                List<string> words = await TextHandler.PreprocessTextAsync(text);
                List<WordCountEntry> entries = CountWord(words);
            }
            catch (Exception)
            {

                throw;
            }

            Console.WriteLine($"File content: {readTask.Result}");
        }
    }
}
