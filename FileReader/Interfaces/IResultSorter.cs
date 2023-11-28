namespace FileReader.Interfaces
{
    internal interface IResultSorter
    {
        abstract static LinkedList<WordCountEntry> SortResults(LinkedList<WordCountEntry> results);
    }
}
