namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var reader = new StreamReader(textFilePath);

            using (reader)
            {
                string input;

                Dictionary<string, int> occurances = new Dictionary<string, int>();

                while ((input = reader.ReadLine()) != null)
                {
                    string[] inputArr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var reader2 = new StreamReader(wordsFilePath);

                    List<string> words = reader2.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                    using (reader2)
                    {
                        foreach (var word in inputArr)
                        {
                            // fault. -> fault

                            if (word.Contains('.'))
                            {
                                int index = word.IndexOf('.');

                                if (words.Contains(word.Substring(0, index)))
                                {
                                    if (!occurances.ContainsKey(word.Substring(0, index)))
                                    {
                                        occurances.Add(word.Substring(0, index), 0);
                                    }

                                    occurances[word.Substring(0, index)]++;
                                }
                            }
                            else if (words.Contains(word))
                            {
                                if (!occurances.ContainsKey(word))
                                {
                                    occurances.Add(word, 0);
                                }

                                occurances[word]++;

                            }
                        }
                    }
                }

                var writer = new StreamWriter(outputFilePath);

                using (writer)
                {
                    foreach (var word in occurances.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}