using FileReader.Interfaces;

namespace FileReader
{
    internal class ResultSorter : IResultSorter
    {
        public static LinkedList<WordCountEntry> SortResults(LinkedList<WordCountEntry> results)
        {
            List<WordCountEntry> sortedList = results.ToList();

            sortedList = sortedList
                .OrderByDescending(entry => entry.Count)
                .ThenBy(entry => entry.Word, StringComparer.OrdinalIgnoreCase)
                .ToList();

            LinkedList<WordCountEntry> sortedLinkedList = new();

            foreach (var entry in sortedList)
                sortedLinkedList.Add(entry);

            return sortedLinkedList;
        }
    }
}
