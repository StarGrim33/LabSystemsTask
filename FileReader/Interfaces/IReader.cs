namespace FileReader.Interfaces
{
    internal interface IReader
    {
        public abstract static Task<string> ReadFile(string filePath);
    }
}
