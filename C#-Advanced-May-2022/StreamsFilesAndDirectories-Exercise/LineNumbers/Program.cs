namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt"; // файл за четене
            string outputFilePath = @"..\..\..\output.txt"; //файл за писане

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            int count = 0;
            List<string> outputLines = new List<string>();

            foreach (string line in lines)
            {
                //"-I was quick to judge him, but it wasn't his fault."
                count++;

                int countLetters = line.Count(char.IsLetter); //37

                int countSymbol = line.Count(char.IsPunctuation); //4

                string modifiedLine = $"Line {count}: {line} ({countLetters})({countSymbol})";
                //"Line 1: -I was quick to judge him, but it wasn't his fault. (37)(4)"
                outputLines.Add(modifiedLine);

            }

            File.WriteAllLines(outputFilePath, outputLines);
        }
    }
}