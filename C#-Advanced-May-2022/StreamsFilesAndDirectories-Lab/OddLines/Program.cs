using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);

            using (reader)
            {
                StreamWriter writer = new StreamWriter(outputFilePath);

                using (writer)
                {
                    int lineNum = 0;

                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                            break;

                        if (lineNum % 2 != 0)
                            writer.WriteLine(line);

                        lineNum++;
                    }
                }
            }
        }
    }
}
