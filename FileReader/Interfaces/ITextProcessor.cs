namespace FileReader.Interfaces
{
    internal interface ITextProcessor
    {
        public abstract static Task<LinkedList<string>> PreprocessTextAsync(string filePath);
    }
}
