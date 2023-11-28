namespace FileReader
{
    internal static class Constants
    {
        public static string FILEPATH = @"C:\Users\Влад и Аня\Desktop\C# course\LabSystemsTask\FileReader\WordsList.txt";
        public static string OUTPUTFILEPATH = @"C:\Users\Влад и Аня\Desktop\C# course\LabSystemsTask\FileReader\ResultPairs.txt";
        public static string LOGFILEPATH = @"C:\Users\Влад и Аня\Desktop\C# course\LabSystemsTask\FileReader\logfile.txt";

        public static Logger logger = new(LOGFILEPATH);
    }
}
