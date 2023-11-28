namespace FileReader.Interfaces
{
    internal interface IWriter
    {
        public abstract static Task WriteFile(string filePath, LinkedList<WordCountEntry> sortedResults);
    }
}
