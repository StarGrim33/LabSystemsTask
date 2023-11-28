namespace FileReader.Interfaces
{
    internal interface IWordCounter
    {
        abstract static LinkedList<WordCountEntry> CountWords(LinkedList<string> words);
    }
}
