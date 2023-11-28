using FileReader.Interfaces;

namespace FileReader
{
    internal class WordCounter : IWordCounter
    {
        public static LinkedList<WordCountEntry> CountWords(LinkedList<string> words)
        {
            LinkedList<WordCountEntry> result = new();

            words.ForEach(word =>
            {
                var entryNode = result.Find(node => node.Word == word);

                if (entryNode != null)
                    entryNode.Data.Count++;
                else
                    result.Add(new WordCountEntry { Word = word, Count = 1 });
            });

            return result;
        }
    }
}
